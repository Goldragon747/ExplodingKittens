using ExplodingKittensDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExplodingKittensDAL
{
    public class ExplodingKittensService
    {
        public CardModelList GetAllCards()
        {
            CardModelList cardList = new CardModelList();
            using (var db = new Pro250_KittensEntities())
            {
                var query = db.Cards.Select(x => x);
                var Cards_List = query.ToList();
                Cards_List.ForEach(cardDetail =>
                   cardList.CardList.Add(
                        new Card()
                        {
                            CardID = cardDetail.CardID
                        }));
            }
            return cardList;
        }
    }

    public EditableModelList GetAllEditableItemsByTagIndex(string letter)
    {
        EditableModelList editableList = new EditableModelList();
        using (var db = new InnovationLabEntities())
        {
            var query = db.Stored_Elements.Where(x => x.TagIndex.ToString().Contains(letter));
            var Stored_Elements_List = query.ToList();
            Stored_Elements_List.ForEach(editableDetail =>
               editableList.EditableDetailsList.Add(
                    new EditableModel()
                    {
                        Tag = editableDetail.Tag,
                        TagContent = (editableDetail.TagContent.Equals("_text_")) ? " " : editableDetail.TagContent,
                        TagIndex = editableDetail.TagIndex
                    }));
        }
        return editableList;
    }

    public EditableModelList GetAllEditableItemsByTagIndex(string letter)
    {
        EditableModelList editableList = new EditableModelList();
        using (var db = new InnovationLabEntities())
        {
            var query = db.Stored_Elements.Where(x => x.TagIndex.ToString().Contains(letter));
            var Stored_Elements_List = query.ToList();
            Stored_Elements_List.ForEach(editableDetail =>
               editableList.EditableDetailsList.Add(
                    new EditableModel()
                    {
                        Tag = editableDetail.Tag,
                        TagContent = editableDetail.TagContent,
                        TagIndex = editableDetail.TagIndex
                    }));
        }
        return editableList;
    }

    public bool IsInTable(string id)
    {
        string result = "";
        using (var db = new InnovationLabEntities())
        {
            var query = from element in db.Stored_Elements
                        where element.TagIndex == id
                        select element;
            foreach (var c in query)
            {
                result += c;
            }
        }
        return (string.IsNullOrEmpty(result)) ? false : true;
    }

    public void addToTable(string id, string tag, string content)
    {
        using (var db = new InnovationLabEntities())
        {
            db.Stored_Elements.Add(new Stored_Elements()
            {
                TagIndex = id,
                Tag = tag,
                TagContent = content
            });
            db.SaveChanges();
        }
    }
    public void Update(string id, string content)
    {
        using (var db = new InnovationLabEntities())
        {
            var element = db.Stored_Elements.Where(x => x.TagIndex == id).First();
            element.TagContent = content;
            db.SaveChanges();
        }
    }
}
