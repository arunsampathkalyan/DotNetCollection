using Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using System.Web.Security;
using System.Xml;

namespace TestlinkWebApi.Controllers
{
    public class UserController : ApiController
    {
        [HttpGet]
        public string Test()
        {
            var testlinkEntities = new testlinkEntities();
            var activeTestRequirements = testlinkEntities.req_specs.Where(t => t.testproject_id == 4).Select(t => t.id).ToList();
            var requirments = new List<Requirement>();
            foreach (var node in testlinkEntities.nodes_hierarchy.Where(t => t.parent_id.HasValue && activeTestRequirements.Contains(t.parent_id.Value) && t.node_type_id == 7).ToList())
            {
                var parentNode = testlinkEntities.nodes_hierarchy.Where(t => t.parent_id.Value.Equals(node.id)).FirstOrDefault();
                if (parentNode != null)
                {
                    var requirement = testlinkEntities.requirements.Where(t => t.id.Equals(node.id)).FirstOrDefault();
                    var requirementVersion = testlinkEntities.req_versions.Where(t => t.id.Equals(parentNode.id)).FirstOrDefault();

                    if (requirement != null && requirementVersion != null)
                    {
                        requirments.Add(new Requirement()
                        {
                            NodeId = node.id,
                            Name = string.Concat(requirement.req_doc_id + ":" + node.name),
                            Version = requirementVersion.version,
                            Revision = requirementVersion.revision,
                            Scope = requirementVersion.scope,
                            ExpectedCoverage = requirementVersion.expected_coverage,
                            Type = ParseEnum<Type>(requirementVersion.type).ToString(),
                            Status = GetEnumDescription<Status>(ParseEnum<Status>(requirementVersion.status))
                        });
                    }
                }
            }

            return "test";
        }

        [HttpGet]
        public List<Requirement> GetRequirements(long projectId)
        {
            var testlinkEntities = new testlinkEntities();
            var activeTestRequirements = testlinkEntities.req_specs.Where(t => t.testproject_id == projectId).Select(t => t.id).ToList();
            var requirments = new List<Requirement>();
            foreach (var node in testlinkEntities.nodes_hierarchy.Where(t => t.parent_id.HasValue && activeTestRequirements.Contains(t.parent_id.Value) && t.node_type_id == 7).ToList())
            {
                var parentNode = testlinkEntities.nodes_hierarchy.Where(t => t.parent_id.Value.Equals(node.id)).FirstOrDefault();
                if (parentNode != null)
                {
                    var requirement = testlinkEntities.requirements.Where(t => t.id.Equals(node.id)).FirstOrDefault();
                    var requirementVersion = testlinkEntities.req_versions.Where(t => t.id.Equals(parentNode.id)).FirstOrDefault();

                    if (requirement != null && requirementVersion != null)
                    {
                        requirments.Add(new Requirement()
                        {
                            NodeId = node.id,
                            Name = string.Concat(requirement.req_doc_id + ":" + node.name),
                            Version = requirementVersion.version,
                            Revision = requirementVersion.revision,
                            Scope = requirementVersion.scope,
                            ExpectedCoverage = requirementVersion.expected_coverage,
                            Type = ParseEnum<Type>(requirementVersion.type).ToString(),
                            Status = GetEnumDescription<Status>(ParseEnum<Status>(requirementVersion.status))
                        });
                    }
                }
            }
            return requirments;
        }

        [HttpPost]
        public string Login(string userName, string password)
        {
            var testlinkEntities = new testlinkEntities();
            var passwordEncrypt = GetMd5Hash(password);
            var user = testlinkEntities.users.Where(u => u.login.Equals(userName) && u.password.Equals(passwordEncrypt) && u.active).FirstOrDefault();
            return user != null ? "Success" : "Failed";
        }

        [HttpGet]
        public List<Project> GetProject()
        {
            var testlinkEntities = new testlinkEntities();
            var activeTestProjects = testlinkEntities.testprojects.Where(t => t.active).Select(t => t.id);
            var List = new List<Project>();
            foreach (var item in testlinkEntities.nodes_hierarchy.Where(t => activeTestProjects.Contains(t.id)))
            {
                var project = new Project();
                project.Id = item.id;
                project.Name = item.name;
                List.Add(project);
            }
            return List;
        }

        public static string GetEnumDescription<TEnum>(TEnum enumObj)
        {
            var description = string.Empty;
            var type = typeof(TEnum);
            var memInfo = type.GetMember(enumObj.ToString());
            var attributes = memInfo[0].GetCustomAttributes(typeof(DescriptionAttribute), false);
            if (attributes != null && attributes.Count() > 0)
            {
                description = ((DescriptionAttribute)attributes[0]).Description;
            }
            return description;
        }

        public static T ParseEnum<T>(string value)
        {
            return (T)Enum.Parse(typeof(T), value, true);
        }

        static string GetMd5Hash(string input)
        {
            // Create a new Stringbuilder to collect the bytes
            // and create a string.
            StringBuilder sBuilder = new StringBuilder();

            using (MD5 md5Hash = MD5.Create())
            {
                // Convert the input string to a byte array and compute the hash.
                byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));

                // Loop through each byte of the hashed data 
                // and format each one as a hexadecimal string.
                for (int i = 0; i < data.Length; i++)
                {
                    sBuilder.Append(data[i].ToString("x2"));
                }
            }

            // Return the hexadecimal string.
            return sBuilder.ToString();
        }

        static bool VerifyMd5Hash(string input, string hash)
        {
            // Hash the input.
            string hashOfInput = GetMd5Hash(input);

            // Create a StringComparer an compare the hashes.
            StringComparer comparer = StringComparer.OrdinalIgnoreCase;

            if (0 == comparer.Compare(hashOfInput, hash))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }

    public class Project
    {
        public long Id;
        public string Name;
    }

    public class Requirement
    {
        public long NodeId;
        public string Name;
        public int Version { get; set; }
        public int Revision { get; set; }
        public string Scope { get; set; }
        public int ExpectedCoverage { get; set; }
        public string Type { get; set; }
        public string Status { get; set; }
    }

    public enum Status
    {
        [Description("Valid")]
        V,
        [Description("Not-Testable")]
        N,
        [Description("Draft")]
        D,
        [Description("Review")]
        R,
        [Description("Rework")]
        W,
        [Description("Finish")]
        F,
        [Description("Implemented")]
        I,
        [Description("Obsolate")]
        O,
        [Description("Update")]
        U
    }

    public enum Type
    {
        Info = 1,
        Feature = 2,
        UseCase = 3,
        Inteface = 4,
        NonFunctional = 5,
        Constarin = 6,
        SystemFunction = 7
    }
}