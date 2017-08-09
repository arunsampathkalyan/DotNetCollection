using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using Secova.NxG.BAS.DAL;
using CelloSaaS.Model;
using CelloSaaS.DAL;
using Secova.NxG.BAS.Model;
using CelloSaaS.Library.DataAccessLayer;


namespace Secova.NxG.BAS.SqlDAL
{
    public class InteractiveQuestionDAL : EntityDAL<InteractiveQuestion>, IInteractiveQuestionDAL
    {

        private string getConnectionStringName()
        {
            return DbMetaData.GetApplicationConnectionString().Name;
        }

        protected override string DoCreate(DataCreateRequest dataCreateRequest)
        {
            if (dataCreateRequest == null)
            {
                string message = string.Format("Create Request is null.");
                throw new ArgumentException(message, "InteractiveQuestionCreateRequest");
            }

            InteractiveQuestion interactiveQuestionEntity = dataCreateRequest.Entity as InteractiveQuestion;
            if (interactiveQuestionEntity == null)
            {
                string message = string.Format("InteractiveQuestion Entity set to null in the DataCreateRequest.");
                throw new ArgumentException(message, "InteractiveQuestionCreateRequest");
            }

            DBAccess dbAccess = new DBAccess(CelloSaaS.Library.DAL.Constants.ApplicationConnectionString);
            //to do
            //FetchQuery fetchQuery = null;

            //if (!string.IsNullOrEmpty(interactiveQuestionEntity.ParentQuestionId))
            //{
            //    string sQuery = "Select DependentTypeId from InteractiveQuestion Where ParentQuestionId = '" + interactiveQuestionEntity.ParentQuestionId + "'";
            //    //interactiveQuestionEntity.DependantTypeId = ((Guid)dbAccess.ExecuteScalar(sQuery, )).ToString();

            //    fetchQuery = new FetchQuery(CelloSaaS.Library.DAL.Constants.ApplicationConnectionString, null, null);
            //    fetchQuery.SelectCondition = sQuery;
            //}

            StringBuilder query = new StringBuilder();
            query.Append("INSERT INTO InteractiveQuestion With (rowlock)(TenantServicePeriodId,QuestionText,ControlTypeId,DataTypeId,DefaultValue, CSSStyle, QuestionCode, IsRequired");
            query.Append(" StartDate, DependentTypeId, CreatedBy, CreatedDate, ParentQuestionId, IsParentQuestion, Status ) ");
            query.Append(" OUTPUT Inserted.QuestionId ");
            query.Append(" values(@TenantServicePeriodId,@QuestionText,@ControlTypeId,@DataTypeId,@DefaultValue, @CSSStyle, @QuestionCode, ");
            query.Append(" @IsRequired,@StartDate, @DependentTypeId, @CreatedBy, @CreatedDate, @ParentQuestionId, @IsParentQuestion, 1 ");
            
            InsertQuery insertQuery = new InsertQuery(CelloSaaS.Library.DAL.Constants.ApplicationConnectionString.ToString());

            //the following commented statement is not available in CelloSaas Version 2.0
            insertQuery.InsertCondition = query;

            CreateGenericParameter(insertQuery, "@QuestionId", interactiveQuestionEntity.QuestionId);
            CreateGenericParameter(insertQuery, "@TenantServicePeriodId", interactiveQuestionEntity.TenantServicePeriodId);
            CreateGenericParameter(insertQuery, "@QuestionText", interactiveQuestionEntity.QuestionText);
            CreateGenericParameter(insertQuery, "@ControlTypeId", interactiveQuestionEntity.ControlTypeId);
            CreateGenericParameter(insertQuery, "@DataTypeId", interactiveQuestionEntity.DataTypeId);
            CreateGenericParameter(insertQuery, "@DefaultValue", interactiveQuestionEntity.DefaultValue);
            CreateGenericParameter(insertQuery, "@CSSStyle", interactiveQuestionEntity.CSSStyle);
            CreateGenericParameter(insertQuery, "@QuestionCode", interactiveQuestionEntity.QuestionCode);
            CreateGenericParameter(insertQuery, "@IsRequired", interactiveQuestionEntity.IsRequired);
            CreateGenericParameter(insertQuery, "@ParentQuestionId", interactiveQuestionEntity.ParentQuestionId);
            CreateGenericParameter(insertQuery, "@ParentQuestionValue", interactiveQuestionEntity.ParentQuestionValue);
            CreateGenericParameter(insertQuery, "@StartDate", interactiveQuestionEntity.StartDate);
            CreateGenericParameter(insertQuery, "@EndDate", interactiveQuestionEntity.EndDate);
            CreateGenericParameter(insertQuery, "@DependentTypeId", interactiveQuestionEntity.DependantTypeId);
            CreateGenericParameter(insertQuery, "@CreatedBy", interactiveQuestionEntity.CreatedBy);
            CreateGenericParameter(insertQuery, "@CreatedDate", DateTime.Now.Date);
            CreateGenericParameter(insertQuery, "@ParentQuestionId", interactiveQuestionEntity.ParentQuestionId);
            CreateGenericParameter(insertQuery, "@IsParentQuestion", interactiveQuestionEntity.IsParentQuestion);
            
            interactiveQuestionEntity.Identifier = dbAccess.InsertAndReturnGUID(insertQuery, "QuestionId");

            return interactiveQuestionEntity.Identifier;
        }

        protected override void DoDelete(DataDeleteRequest dataDeleteRequest)
        {
            throw new NotImplementedException();
        }

        protected override InteractiveQuestion DoFetch(DataFetchRequest dataFetchRequest)
        {
            throw new NotImplementedException();
        }

        protected override Dictionary<string, InteractiveQuestion> DoSearch(DataSearchRequest dataSearchRequest)
        {
            IDataReader dbDataReader = null;
            if (dataSearchRequest == null)
                throw new ArgumentException("DataSearchRequest is null", "dataSearchRequest");
            try
            {
                FetchQuery fetchQuery = null;

                StringBuilder query = new StringBuilder();
                query.Append("Select TenantServicePeriodId, QuestionText, ControlTypeId, DataTypeId, DefaultValue, ");
                query.Append(" CSSStyle, QuestionCode, IsRequired, ParentQuestionId, ParentQuestionValue, StartDate, EndDate, ");
                query.Append(" DependentTypeId, CreatedBy, CreatedDate, UpdatedBy, UpdatedDate, [Status] FROM InteractiveQuestion ");

                fetchQuery = new FetchQuery(CelloSaaS.Library.DAL.Constants.ApplicationConnectionString, null, null);
                fetchQuery.SelectCondition = query;

                DBAccess dbAccess = new DBAccess(CelloSaaS.Library.DAL.Constants.ApplicationConnectionString);
                dbDataReader = dbAccess.ExecuteReader(fetchQuery);

                Dictionary<string, InteractiveQuestion> interactiveQuestion = ConvertInteractiveQuestionListToDictionary(GetInteractiveQuestionListFromReader(dbDataReader));
                return interactiveQuestion;
            }
            catch (Exception ex)
            { }
            finally
            {
                if (dbDataReader != null)
                    dbDataReader.Close();
            }
            return null;
        }

        protected override void DoUpdate(DataUpdateRequest dataUpdateRequest)
        {
            throw new NotImplementedException();
        }

        protected override void DoSoftDelete(DataDeleteRequest dataDeleteRequest)
        {
            if (dataDeleteRequest == null)
            {
                string message = string.Format("Delete Request is null.");
                throw new ArgumentException(message, "InteractiveQuestionDeleteRequest");
            }

            if (string.IsNullOrEmpty(dataDeleteRequest.Identifier))
            {
                string message = string.Format("Delete Request Identifier is null or empty.");
                throw new ArgumentException(message, "InteractiveQuestionDeleteRequest");
            }

            StringBuilder query = new StringBuilder();

            //Note: It is soft delete only - InteractiveQuestionDataLookup
            query.Append("Update InteractiveQuestionDataLookup set Status = 0 where QuestionId=@QuestionId");

            DeleteQuery deleteQuery = new DeleteQuery(CelloSaaS.Library.DAL.Constants.ApplicationConnectionString.ToString());
            deleteQuery.DeleteCondition = query;


            CreateGenericParameter(deleteQuery, "@QuestionId", dataDeleteRequest.Identifier);

            DBAccess dbAccess = new DBAccess(CelloSaaS.Library.DAL.Constants.ApplicationConnectionString.ToString());

            if (dbAccess.ExecuteNonQuery(deleteQuery) < 1)
            {
                throw new ArgumentException(string.Format("InteractiveQuestionDataLookup details is not deleted successfully."));
            }

            //Note: It is soft delete only - InteractiveQuestion
            query.Append("Update InteractiveQuestion set Status = 0 where QuestionId=@QuestionId");

            deleteQuery = new DeleteQuery(CelloSaaS.Library.DAL.Constants.ApplicationConnectionString.ToString());
            deleteQuery.DeleteCondition = query;


            CreateGenericParameter(deleteQuery, "@QuestionId", dataDeleteRequest.Identifier);

            if (dbAccess.ExecuteNonQuery(deleteQuery) < 1)
            {
                throw new ArgumentException(string.Format("InteractiveQuestion details is not deleted successfully."));
            }

        }

        public List<InteractiveQuestion> GetAllInteractiveQuestions()
        {
            List<InteractiveQuestion> objInteractiveQuestions = new List<InteractiveQuestion>();
            List<InteractiveQuestion> objInteractiveQuestionList = new List<InteractiveQuestion>();

            using (SqlConnection sqlConnection = new SqlConnection())
            {
                sqlConnection.ConnectionString = ConfigurationManager.ConnectionStrings["ApplicationConnectionString"].ConnectionString;
                sqlConnection.Open();
                using (SqlCommand sqlCommand = new SqlCommand())
                {
                    //select the list of interactive questions
                    sqlCommand.CommandText = "Select QuestionId, QuestionText, [ControlTypeId], [IsRequired], DependentTypeId, ParentQuestionId, IsParentQuestion, DefaultValue, QuestionCode from InteractiveQuestion where status = 1 ";
                    sqlCommand.Connection = sqlConnection;

                    using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter())
                    {
                        sqlDataAdapter.SelectCommand = sqlCommand;
                        DataSet ds = new DataSet();
                        sqlDataAdapter.Fill(ds);
                        DataTable dt = ds.Tables[0];
                        foreach (DataRow dr in dt.Rows)
                        {
                            string sParentQuestionId = string.Empty;
                            string parentId = string.Empty; ;

                            if (!string.IsNullOrEmpty(dr["ParentQuestionId"].ToString()))
                                parentId = dr["ParentQuestionId"].ToString();

                            objInteractiveQuestions.Add(new InteractiveQuestion()
                            {
                                QuestionId = dr["QuestionId"].ToString(),
                                QuestionText = dr["QuestionText"].ToString(),
                                ControlTypeId = dr["ControlTypeId"].ToString(),
                                IsRequired = (bool)dr["IsRequired"],
                                DependantTypeId = dr["DependentTypeId"].ToString(),
                                ParentQuestionId = parentId,
                                IsParentQuestion = (bool)dr["IsParentQuestion"],
                                DefaultValue = dr["DefaultValue"].ToString(),
                                QuestionCode = dr["QuestionCode"].ToString(),
                            }
                            );
                        }
                    }
                    foreach (InteractiveQuestion items in objInteractiveQuestions)
                    {
                        //ControlType
                        sqlCommand.CommandText = "Select ControlTypeName from LookupControlType where ControlTypeId = '" + items.ControlTypeId + "'";
                        LookupControlType objControlType = new LookupControlType();

                        using (SqlDataAdapter sda = new SqlDataAdapter())
                        {
                            sda.SelectCommand = sqlCommand;
                            DataSet ds1 = new DataSet();
                            sda.Fill(ds1);
                            DataTable dt1 = ds1.Tables[0];
                            foreach (DataRow dr in dt1.Rows)
                            {
                                objControlType.ControlTypeName = dr["ControlTypeName"].ToString();
                            }
                        }

                        items.LookupControlType = objControlType;

                        //DependentType
                        sqlCommand.CommandText = "Select DependantTypeName from LookupDependantType where DependantTypeId = '" + items.DependantTypeId + "'";
                        LookupDependantType objDependantType = new LookupDependantType();

                        using (SqlDataAdapter sda = new SqlDataAdapter())
                        {
                            sda.SelectCommand = sqlCommand;
                            DataSet ds1 = new DataSet();
                            sda.Fill(ds1);
                            DataTable dt1 = ds1.Tables[0];
                            foreach (DataRow dr in dt1.Rows)
                            {
                                objDependantType.DependantTypeName = dr["DependantTypeName"].ToString();
                            }
                        }

                        items.LookupDependantType = objDependantType;

                        sqlCommand.CommandText = "Select OptionId, OptionName from InteractiveQuestionDataLookup where QuestionId = '" + items.QuestionId + "'";
                        List<InteractiveQuestionDataLookup> objListOfOption = new List<InteractiveQuestionDataLookup>();

                        using (SqlDataAdapter sda = new SqlDataAdapter())
                        {
                            sda.SelectCommand = sqlCommand;
                            DataSet ds1 = new DataSet();
                            sda.Fill(ds1);
                            DataTable dt1 = ds1.Tables[0];
                            foreach (DataRow dr in dt1.Rows)
                            {
                                objListOfOption.Add(new InteractiveQuestionDataLookup()
                                {
                                    OptionId = dr["OptionId"].ToString(),
                                    OptionName = dr["OptionName"].ToString(),
                                }
                                );
                            }
                        }

                        items.InteractiveQuestionDataLookup = objListOfOption;
                        objInteractiveQuestionList.Add(items);
                    }

                }
            }
            return objInteractiveQuestionList;
        }

        public List<InteractiveQuestion> GetAllParentInteractiveQuestions()
        {
            List<InteractiveQuestion> parentQuestionList = new List<InteractiveQuestion>();

            using (SqlConnection sqlConnection = new SqlConnection())
            {
                sqlConnection.ConnectionString = ConfigurationManager.ConnectionStrings["ApplicationConnectionString"].ConnectionString;
                sqlConnection.Open();
                using (SqlCommand sqlCommand = new SqlCommand())
                {
                    sqlCommand.CommandText = "Select QuestionId, QuestionText from InteractiveQuestion Where IsParentQuestion = 1 ";

                    sqlCommand.Connection = sqlConnection;
                    using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter())
                    {
                        sqlDataAdapter.SelectCommand = sqlCommand;
                        DataSet ds = new DataSet();
                        sqlDataAdapter.Fill(ds);
                        DataTable dt = ds.Tables[0];
                        foreach (DataRow dr in dt.Rows)
                        {
                            parentQuestionList.Add(new InteractiveQuestion()
                            {
                                QuestionId = dr["QuestionId"].ToString(),
                                QuestionText = dr["QuestionText"].ToString(),
                            }
                            );
                        }
                    }
                }
            }
            return parentQuestionList;
        }

        #region Private Members
        private void CreateGenericParameter(Query tranQuery, string parameterName, object parameterValue)
        {
            if (tranQuery == null)
            {
                string message = string.Format("TransactionalQuery object is null.");
                throw new ArgumentException(message, "CreateGenericParameter");
            }

            if (string.IsNullOrEmpty(parameterName))
            {
                string message = string.Format("Parameter name is not set.");
                throw new ArgumentException(message, "CreateGenericParameter");
            }

            //create the parameter
            DbParameter dbParameter = tranQuery.CreateParameter();

            //assign the name of the parameter
            dbParameter.ParameterName = parameterName;

            //assigning the value to the parameter
            if (parameterValue == null)
            {
                dbParameter.Value = DBNull.Value;
            }
            else
            {
                if (parameterValue is string)
                {
                    if (string.IsNullOrEmpty((string)parameterValue))
                    {
                        dbParameter.Value = DBNull.Value;
                    }
                    else
                    {
                        dbParameter.Value = parameterValue;
                    }
                }
                else
                {
                    dbParameter.Value = parameterValue;
                }
            }

            //adding the parameter to the parmeter collection
            tranQuery.AddParameter(dbParameter);
        }

        /// <summary>
        /// This method is used to assign all the field values from data reader to list
        /// </summary>
        /// <param name="dataReader"></param>
        /// <returns></returns>
        private List<InteractiveQuestion> GetInteractiveQuestionListFromReader(IDataReader dataReader)
        {
            if (dataReader == null && dataReader.IsClosed)
            {
                string message = string.Format("Reader is null or closed.", "InteractiveQuestion Reader");
                throw new ArgumentException(message);
            }

            List<InteractiveQuestion> interactiveQuestionList = new List<InteractiveQuestion>();

            while (dataReader.Read())
            {

                InteractiveQuestion interactiveQuestion = new InteractiveQuestion();

                //Assign InteractiveQuestion values
                interactiveQuestion.QuestionId = dataReader["QuestionId"].ToString();
                interactiveQuestion.TenantServicePeriodId = dataReader["TenantServicePeriodId"].ToString();
                interactiveQuestion.QuestionText = dataReader["QuestionText"].ToString();
                interactiveQuestion.ControlTypeId = dataReader["ControlTypeId"].ToString();
                interactiveQuestion.DataTypeId = dataReader["DataTypeId"].ToString();
                interactiveQuestion.DefaultValue = dataReader["DefaultValue"].ToString();
                interactiveQuestion.CSSStyle = dataReader["CSSStyle"].ToString();
                interactiveQuestion.QuestionCode = dataReader["QuestionCode"].ToString();
                interactiveQuestion.ParentQuestionId = dataReader["ParentQuestionId"].ToString();
                interactiveQuestion.ParentQuestionValue = dataReader["ParentQuestionValue"].ToString();
                if (!string.IsNullOrEmpty(dataReader["StartDate"].ToString()))
                {
                    interactiveQuestion.StartDate = Convert.ToDateTime(dataReader["StartDate"].ToString());
                }
                if (!string.IsNullOrEmpty(dataReader["EndDate"].ToString()))
                {
                    interactiveQuestion.EndDate = Convert.ToDateTime(dataReader["EndDate"].ToString());
                }
                if (!string.IsNullOrEmpty(dataReader["IsRequired"].ToString()))
                {
                    interactiveQuestion.IsRequired = Convert.ToBoolean(dataReader["IsRequired"].ToString());
                }

                if (!string.IsNullOrEmpty(dataReader["Status"].ToString()))
                {
                    interactiveQuestion.Status = Convert.ToBoolean(dataReader["Status"].ToString());
                }

                interactiveQuestion.CreatedBy = dataReader["CreatedBy"].ToString();
                if (!string.IsNullOrEmpty(dataReader["CreatedDate"].ToString()))
                {
                    interactiveQuestion.CreatedDate = Convert.ToDateTime(dataReader["CreatedDate"].ToString());
                }
                interactiveQuestion.UpdatedBy = dataReader["UpdatedBy"].ToString();
                if (!string.IsNullOrEmpty(dataReader["UpdatedDate"].ToString()))
                {
                    interactiveQuestion.UpdatedDate = Convert.ToDateTime(dataReader["UpdatedDate"].ToString());
                }

                interactiveQuestionList.Add(interactiveQuestion);
            }

            if (interactiveQuestionList.Count < 1)
                return null;

            return interactiveQuestionList;
        }

        /// <summary>
        /// This method is used to convert the list to dictionary
        /// </summary>
        /// <param name="interactiveQuestionList"></param>
        /// <returns></returns>
        private Dictionary<string, InteractiveQuestion> ConvertInteractiveQuestionListToDictionary(List<InteractiveQuestion> interactiveQuestionList)
        {
            Dictionary<string, InteractiveQuestion> interactiveQuestions = null;
            if (interactiveQuestionList != null)
            {
                if (interactiveQuestionList.Count > 0)
                {
                    interactiveQuestions = new Dictionary<string, InteractiveQuestion>();
                    foreach (InteractiveQuestion interactiveQuestion in interactiveQuestionList)
                    {
                        interactiveQuestions.Add(interactiveQuestion.Identifier, interactiveQuestion);
                    }
                }
            }
            return interactiveQuestions;
        }

        #endregion
    }
}
