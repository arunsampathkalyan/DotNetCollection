using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Secova.NxG.BAS.Model;
using Secova.NxG.BAS.ServiceProxies;

namespace NxGApplication.Controllers
{
    public class InteractiveQuestionController : Controller
    {
  
        public ActionResult Index()
        {
            List<InteractiveQuestion> lstInteractiveQuestions = InteractiveQuestionProxy.GetAllInteractiveQuestionsOld();

            //Dictionary<string, InteractiveQuestion> interactiveQuestions = InteractiveQuestionProxy.GetAllInteractiveQuestions();

            //List<InteractiveQuestion> lstInteractiveQuestions = new List<InteractiveQuestion>(interactiveQuestions.Values);
            
            List<InteractiveQuestion> interactiveQuestionEmployeeList = new List<InteractiveQuestion>();
            List<InteractiveQuestion> interactiveQuestionSpouseList = new List<InteractiveQuestion>();
            List<InteractiveQuestion> interactiveQuestionChildList = new List<InteractiveQuestion>();

            List<SelectListItem> dependantTypeList = DependantTypeList();
            ViewData["DependantTypeValues"] = dependantTypeList;

            foreach (InteractiveQuestion items in lstInteractiveQuestions)
            {
                if (items.LookupDependantType.DependantTypeName == "Self")
                    interactiveQuestionEmployeeList.Add(items);
                if (items.LookupDependantType.DependantTypeName == "Spouse")
                    interactiveQuestionSpouseList.Add(items);
                if (items.LookupDependantType.DependantTypeName == "Child")
                    interactiveQuestionChildList.Add(items);
            }

            ViewData["InteractiveQuestionEmployeeList"] = interactiveQuestionEmployeeList;
            ViewData["InteractiveQuestionSpouseList"] = interactiveQuestionSpouseList;
            ViewData["InteractiveQuestionChildList"] = interactiveQuestionChildList;

            return View();
        }

        public ActionResult Add()
        {
            List<SelectListItem> controlTypeList = ControlTypeList();
            ViewData["ControlTypeValues"] = controlTypeList;

            List<SelectListItem> dataTypeList = DataTypeList();
            ViewData["DataTypeValues"] = dataTypeList;

            List<SelectListItem> dependantTypeList = DependantTypeList();
            ViewData["DependantTypeValues"] = dependantTypeList;

            List<SelectListItem> parentQuestionList = ParentQuestionsList();
            ViewData["ParentQuestionList"] = parentQuestionList;

            return View();
        }

        [HttpPost]
        public ActionResult Add([Bind(Exclude = "Id")]InteractiveQuestion interactiveQuestionToCreate)
        {
            
            InteractiveQuestion objInteractiveQuestion = new InteractiveQuestion();

            String[] sListOfValues = new String[] { "," };
            string schkMakeRequiredQuestion = string.Empty;

            //if (!ModelState.IsValid)
            //{
            //    foreach (var modelStateValue in ViewData.ModelState.Values)
            //    {
            //        foreach (var error in modelStateValue.Errors)
            //        {
            //            var errorMessage = error.ErrorMessage;
            //            var exception = error.Exception;
            //            return Json(new { Errors = errorMessage }, JsonRequestBehavior.AllowGet);
            //        }
            //    }
            //}

            interactiveQuestionToCreate.ControlTypeId = Request.Form["ControlTypeValues"].ToString();
            interactiveQuestionToCreate.DataTypeId = Request.Form["DataTypeValues"].ToString();
            interactiveQuestionToCreate.DependantTypeId = Request.Form["DependantTypeValues"].ToString();

            if (!string.IsNullOrEmpty(Request.Form["ParentQuestionList"].ToString()))
                interactiveQuestionToCreate.ParentQuestionId = Request.Form["ParentQuestionList"].ToString();

            //Splitting the list of options for answers
            schkMakeRequiredQuestion = Request.Form["hdnOptionsForAnswers"];
            sListOfValues = schkMakeRequiredQuestion.Split(sListOfValues, StringSplitOptions.None);

            try
            {
                string interactiveQuestionId = InteractiveQuestionProxy.AddInteractiveQuestions(interactiveQuestionToCreate);

                if (interactiveQuestionId != null)
                {
                    foreach (string s in sListOfValues)
                    {
                        InteractiveQuestionProxy.InsertListOfAnswerOptions(s, interactiveQuestionId);
                    }
                }
                List<InteractiveQuestionDataLookup> lValues = InteractiveQuestionProxy.GetInteractiveQuestionDataLookup(interactiveQuestionId);
                objInteractiveQuestion.InteractiveQuestionDataLookup = lValues;

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Delete()
        {
            return View();
        }


        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Delete(string id, string confirmButton)
        {
            if (confirmButton == "Ok")
            {
                if (!string.IsNullOrEmpty(id.ToString()))
                {
                    InteractiveQuestionProxy.DeleteInteractiveQuestions(id);
                }
            }

            return RedirectToAction("Index");
        }

        //[AcceptVerbs(HttpVerbs.Post)]
        //public ActionResult Delete(string confirmButton)
        //{
        //    string id = Request.Params["id"] != null ? Convert.ToString(Request.Params["id"]) : string.Empty; ;
        //    if (confirmButton == "Ok")
        //    {
        //        if (!string.IsNullOrEmpty(id))
        //        {
        //            objInteractiveQuestionDAL.DeleteInteractiveQuestions(id);
        //        }
        //    }

        //    return RedirectToAction("Index");
        //}

        public ActionResult Edit(string id)
        {
            //Through user defined function
            List<SelectListItem> controlTypeList = ControlTypeList();
            ViewData["ControlTypeValues"] = controlTypeList;

            List<SelectListItem> dataTypeList = DataTypeList();
            ViewData["DataTypeValues"] = dataTypeList;

            List<SelectListItem> dependantTypeList = DependantTypeList();
            ViewData["DependantTypeValues"] = dependantTypeList;

            List<SelectListItem> parentQuestionList = ParentQuestionsList();
            ViewData["ParentQuestionList"] = parentQuestionList;

            //Dictionary<string, InteractiveQuestion> interactiveQuestions = InteractiveQuestionProxy.GetAllInteractiveQuestions();
            //List<InteractiveQuestion> lstInteractiveQuestions = new List<InteractiveQuestion>(interactiveQuestions.Values);

            List<InteractiveQuestion> lstInteractiveQuestions = InteractiveQuestionProxy.GetAllInteractiveQuestionsOld();

            var toEdit = (from NxGIQ in lstInteractiveQuestions
                          where NxGIQ.QuestionId == id
                          select NxGIQ).First();

            return View(toEdit);

        }


        [HttpPost]
        public ActionResult Edit(string id, InteractiveQuestion interactiveQuestionsToEdit)
        {
            try
            {
                // TODO: Add update logic here

                //Dictionary<string, InteractiveQuestion> interactiveQuestions = InteractiveQuestionProxy.GetAllInteractiveQuestions();
                //List<InteractiveQuestion> lstInteractiveQuestions = new List<InteractiveQuestion>(interactiveQuestions.Values);
                List<InteractiveQuestion> lstInteractiveQuestions = InteractiveQuestionProxy.GetAllInteractiveQuestionsOld();

                var toEdit = (from NxGIQ in lstInteractiveQuestions
                              where NxGIQ.QuestionId == id
                              select NxGIQ).First();


                //
                string schkMakeRequiredQuestion = Request.Form["hdnOptionsForAnswers"];

                interactiveQuestionsToEdit.QuestionId = id;

                String[] sListOfValues = new String[] { "," };

                //Splitting the list of options for answers
                sListOfValues = schkMakeRequiredQuestion.Split(sListOfValues, StringSplitOptions.None);

                if (!ModelState.IsValid)
                {
                    foreach (var modelStateValue in ViewData.ModelState.Values)
                    {
                        foreach (var error in modelStateValue.Errors)
                        {
                            var errorMessage = error.ErrorMessage;
                            var exception = error.Exception;
                            return Json(new { Errors = errorMessage }, JsonRequestBehavior.AllowGet);
                        }
                    }
                }
                try
                {
                    if (interactiveQuestionsToEdit.QuestionId != null)
                    {
                        InteractiveQuestionProxy.DeleteListOfAnswerOptions(interactiveQuestionsToEdit.QuestionId);

                        foreach (string s in sListOfValues)
                        {
                            InteractiveQuestionProxy.UpdateListOfAnswerOptions(s, interactiveQuestionsToEdit.QuestionId);
                        }
                    }
                    List<InteractiveQuestionDataLookup> lValues = InteractiveQuestionProxy.GetInteractiveQuestionDataLookup(interactiveQuestionsToEdit.QuestionId);

                    interactiveQuestionsToEdit.InteractiveQuestionDataLookup = lValues;

                    InteractiveQuestionProxy.UpdateInteractiveQuestion(interactiveQuestionsToEdit);

                    return RedirectToAction("Index");
                }
                catch
                {
                    return View();
                }

            }
            catch
            {
                return View();
            }
        }

        #region private methods
        private List<SelectListItem> ControlTypeList()
        {
            List<LookupControlType> lstControlType = InteractiveQuestionProxy.GetControlTypeList();

            List<SelectListItem> items = new List<SelectListItem>();

            for (int i = 0; i < lstControlType.Count; i++)
            {
                items.Add(new SelectListItem { Text = lstControlType[i].ControlTypeName, Value = lstControlType[i].ControlTypeId.ToString() });
            }
            return items;
        }

        private List<SelectListItem> DataTypeList()
        {
            List<LookupDataType> lstDataType = InteractiveQuestionProxy.GetDataTypeList();

            List<SelectListItem> items = new List<SelectListItem>();

            for (int i = 0; i < lstDataType.Count; i++)
            {
                items.Add(new SelectListItem { Text = lstDataType[i].DataTypeName, Value = lstDataType[i].DataTypeId.ToString() });
            }
            return items;
        }

        private List<SelectListItem> DependantTypeList()
        {
            List<LookupDependantType> lstDependantType = InteractiveQuestionProxy.GetDependantTypeList();

            List<SelectListItem> items = new List<SelectListItem>();

            for (int i = 0; i < lstDependantType.Count; i++)
            {
                if (lstDependantType[i].DependantTypeName == "Self")
                    items.Add(new SelectListItem { Text = "Employee", Value = lstDependantType[i].DependantTypeId.ToString() });
                else
                    items.Add(new SelectListItem { Text = lstDependantType[i].DependantTypeName, Value = lstDependantType[i].DependantTypeId.ToString() });
            }
            return items;
        }

        private List<SelectListItem> ParentQuestionsList()
        {
            List<InteractiveQuestion> lstParentInteractiveQuestions = InteractiveQuestionProxy.GetAllParentInteractiveQuestions();
            
            List<SelectListItem> items = new List<SelectListItem>();

            for (int i = 0; i < lstParentInteractiveQuestions.Count; i++)
            {
                items.Add(new SelectListItem { Text = lstParentInteractiveQuestions[i].QuestionText, Value = lstParentInteractiveQuestions[i].QuestionId.ToString() });
            }
            return items;
        }


        #endregion


    }
}
