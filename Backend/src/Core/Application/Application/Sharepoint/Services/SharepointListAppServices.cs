using Microsoft.SharePoint.Client;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using Core.Data.Models;
using SP = Microsoft.SharePoint.Client;
using Core.Application.Sharepoint.Services;

namespace Core.Application.Helpers
{

  /// <summary>
  /// HR Sharepoint Add-in
  /// 
  /// Classe usada para facilitar o uso de classes para trabalhar com componentes de lista
  /// É livre a alteração e criação de novas funcionalidades desde que testadas devidamente
  /// 
  /// 2018 Risc Services Ltda
  /// </summary>

  public class SharepointListAppServices : SharepointAppServiceTemplate
    {

        public ListCreationInformation CreationInfo { get; set; }

        public List NewList { get; set; }

        public SharepointListAppServices(ClientContext clientContext) : base(clientContext)
        {
        }

        public string getXMLTextField(string Name, string staticName, string displayName) {

            return $@"<Field Type='Text' Name='{ Name }' StaticName='{ staticName }'" +
                " DisplayName='{ displayName }' > </Field>";
        }

        public string getXMLDateTimeField(string Name, string staticName, string displayName, string Format = "DateOnly",
            string Default = "[Today]")
        {

            return $@"<Field  Type='DateTime' Name='{ Name }' StaticName='{ staticName }' DisplayName='{ displayName }' Format='{ Format }'> <Default>{ Default }</Default></Field>";
        }

        public string getXMLNumberStrictedField(string Name, string staticName, string displayName,
            int Min, int Max) => $@"<Field Type='Number' Name='{ Name }' StaticName='{ staticName }' DisplayName = '{ displayName }' Min='{ Min }' Max='{ Max }'> </Field>";

        public string getXMLNumberField(string Name, string staticName, string displayName) => $@"<Field Type='Number' Name='{ Name }' StaticName='{ staticName }' DisplayName = '{ displayName }'> </Field>";


        public string getXMLUserField(string Name, string staticName, string displayName) {

            return $@"<Field  Type='User' Name='{ Name }' StaticName='{ staticName }' DisplayName='{ displayName }' ></Field>";


        }

        public IList<QuestaoSPList> getMultipleQuestionsNumberFieldsCollection(StringCollection Questions, string questionPrefix, int index)
        {

            IList<QuestaoSPList> Questoes = new List<QuestaoSPList>();
            
            foreach (var Question in Questions)
            {
                Questoes.Add(new QuestaoSPList(questionPrefix + index, questionPrefix + index, Question, 1, 5));
                index++;
            }

            return Questoes;
        }

        public string getXMLFieldNumberQuestionByModel(QuestaoSPList Questao) => $@"<Field Type='Number' Name='{ Questao.Name }' StaticName='{ Questao.staticName }' DisplayName = '{ Questao.displayName }' Min='{ Questao.Min }' Max='{ Questao.Max }'> </Field>";


        public string getXMLSurveyGridChoiceQuestion(string Name, string staticName, string displayName,
            StringCollection GridTxts, StringCollection Choices, int Min = 1, int Max = 5,  string Required = "TRUE" )
        {
            string xmlField = "";

            xmlField += $@"<Field Type='GridChoice' DisplayName='{displayName}' Required='{Required}' GridStartNum='{Min}' GridEndNum='{Max}' ";

             for (int i = 0; i <3; i++)
            {
                xmlField += $@"GridTxtRng{(i+1)} = {GridTxts[i]}' ";
                i++;
            }

            xmlField += $@"StaticName='{ staticName }' Name='{ Name }'>";

            xmlField += "<CHOICES>";

            foreach (var Choice in Choices)
            {

                xmlField += $@"<CHOICE>{ Choice }</CHOICE>";

            }
            

            xmlField +=  "</CHOICES></Field>";

            return xmlField;

        }

        public Field execXMLField(SP.List List, string XML)
        {
            return List.Fields.AddFieldAsXml(XML, true, AddFieldOptions.AddFieldInternalNameHint);

        }

        public void setListCreationInfo(string Title, string Description, int TemplateType) {

            this.CreationInfo = new ListCreationInformation();
            CreationInfo.Title = Title;
            CreationInfo.Description = Description;
            CreationInfo.TemplateType = TemplateType;


        }

        public SP.List getNewList() {

            SP.List newList = ClientContext.Web.Lists.Add(this.CreationInfo);
            return newList;
        }

        public bool checkIfListExists(SP.ListCollection listCollection, string List) {

            ClientContext.Load(listCollection, lists => lists.Include(list => list.Title)
            .Where(list => list.Title == List));

            this.ExecuteRequest();

            if (listCollection.Count > 0)
            {
                return true;

            }

            return false;

        }

        public void Update(List List) => List.Update();

    }
}