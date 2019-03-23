using Microsoft.SharePoint.Client;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using RiscServicesHRSharepointAddIn.Models;
using SP = Microsoft.SharePoint.Client;
namespace RiscServicesHRSharepointAddIn.Helpers
{

  /// <summary>
  /// HR Sharepoint Add-in
  /// 
  /// Classe usada para facilitar o uso de classes para trabalhar com componentes de lista
  /// É livre a alteração e criação de novas funcionalidades desde que testadas devidamente
  /// 
  /// 2018 Risc Services Ltda
  /// </summary>

  public class SPListComponentsHelper : SPObjectsHelperTemplate
    {

        public ListCreationInformation creationInfo { get; set; }

        public SP.List newList { get; set; }

        public SPListComponentsHelper(ClientContext clientContext) : base(clientContext)
        {
        }

        public String getXMLTextField(string Name, string staticName, string displayName) {

            return "<Field Type='Text' Name='"+ Name + "' StaticName='"+ staticName + "'" +
                " DisplayName='"+ displayName + "' > </Field>";
        }

        public String getXMLDateTimeField(string Name, string staticName, string displayName, string Format = "DateOnly",
            string Default = "[Today]")
        {

            return "<Field  Type='DateTime' Name='"+ Name + "' StaticName='"+ staticName + "' " +
                "DisplayName='"+ displayName + "' Format='"+ Format + "'> <Default>"+ Default + "</Default></Field>";
        }

        public String getXMLNumberStrictedField(string Name, string staticName, string displayName,
            int Min, int Max)
        {


            return "<Field Type='Number' Name='"+ Name + "' StaticName='"+ staticName + "' " +
                "DisplayName = '"+ displayName + "' Min='"+ Min + "' Max='"+ Max + "'> </Field>";

        }

        public String getXMLNumberField(string Name, string staticName, string displayName)
        {


            return "<Field Type='Number' Name='" + Name + "' StaticName='" + staticName + "' " +
                "DisplayName = '" + displayName + "'> </Field>";

        }

        public String getXMLUserField(string Name, string staticName, string displayName) {

            return "<Field  Type='User' Name='"+ Name + "' StaticName='"+ staticName + "' DisplayName='"+ displayName + "' ></Field>";


        }

        public IList<QuestaoSPList> getMultipleQuestionsNumberFieldsCollection(StringCollection Questions, String questionPrefix, int index)
        {

            IList<QuestaoSPList> Questoes = new List<QuestaoSPList>();
            
            foreach (var Question in Questions)
            {
                QuestaoSPList Questao = new QuestaoSPList();
                Questao.Max = 5;
                Questao.Min = 1;
                Questao.Name = questionPrefix + index;
                Questao.staticName = questionPrefix + index;
                Questao.displayName = Question;
                Questoes.Add(Questao);
                index++;
            }

            return Questoes;
        }

        public String GetXMLFieldNumberQuestionByModel(QuestaoSPList Questao)
        {
            return "<Field Type='Number' Name='" + Questao.Name + "' StaticName='" + Questao.staticName + "' " +
              "DisplayName = '" + Questao.displayName + "' Min='" + Questao.Min + "' Max='" + Questao.Max + "'> </Field>";
        }


        public String getXMLSurveyGridChoiceQuestion(string Name, string staticName, string displayName, 
            StringCollection GridTxts, StringCollection Choices, int Min = 1, int Max = 5,  String Required = "TRUE" )
        {
            string xmlField = "";

            xmlField += "<Field Type='GridChoice' DisplayName='"+displayName+"' Required='"+Required+"' GridStartNum='"+Min+"'" +
                " GridEndNum='"+Max+"' ";

         
                  for (int i = 0; i <3; i++)
            {
                xmlField += "GridTxtRng"+(i+1)+"='" + GridTxts[i]+ "' ";
                i++;
            }

            xmlField += "StaticName='" + staticName + "' Name='" + Name + "'>";

            xmlField += "<CHOICES>";

            foreach (var Choice in Choices)
            {

                xmlField += "<CHOICE>" + Choice + "</CHOICE>";

            }
            

            xmlField +=  "</CHOICES></Field>";

            return xmlField;

        }

        public Field execXMLField(SP.List List, String XML)
        {
            return List.Fields.AddFieldAsXml(XML, true, AddFieldOptions.AddFieldInternalNameHint);

        }

        public void setListCreationInfo(string Title, string Description, int TemplateType) {

            this.creationInfo = new ListCreationInformation();
            creationInfo.Title = Title;
            creationInfo.Description = Description;
            creationInfo.TemplateType = TemplateType;


        }

        public SP.List getNewList() {

            SP.List newList = clientContext.Web.Lists.Add(this.creationInfo);
            return newList;
        }

        public bool checkIfListExists(SP.ListCollection listCollection, string List) {

            clientContext.Load(listCollection, lists => lists.Include(list => list.Title)
            .Where(list => list.Title == List));

            this.Save();

            if (listCollection.Count > 0)
            {
                return true;

            }

            return false;

        }

        public void Update(SP.List List)
        {

            List.Update();

        }





    }
}