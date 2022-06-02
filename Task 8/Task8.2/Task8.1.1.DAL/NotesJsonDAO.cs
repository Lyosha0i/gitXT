using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Epam.Notes.Common.Entities;
using Epam.Notes.DAL.Interfaces;
using Newtonsoft.Json;

namespace Epam.Notes.DAL.JsonDAL
{
    public class NotesJsonDAO : INotesDAO
    {
        public const string JsonFilesPath = @"C:\Users\Cat Elio\source\repos\NotesManager\Files\";

        public Note AddNote(string text, DateTime creationDate)
        {
            var note = new Note(text);

            string json = JsonConvert.SerializeObject(note);

            File.WriteAllText(GetFilePathById(note.ID), json);

            return note;
        }

        public void RemoveNote(int id)
        {
            if (File.Exists(GetFilePathById(id)))
                File.Delete(GetFilePathById(id));

            else throw new FileNotFoundException(
                string.Format("File with name {0} at path {1} isn't created!", id + ".json", JsonFilesPath));
        }

        public void EditNote(int id, string newText)
        {
            if (!File.Exists(GetFilePathById(id)))
                throw new FileNotFoundException(
                    string.Format("File with name {0} at path {1} isn't created!", 
                        id, JsonFilesPath));

            Note note = JsonConvert.DeserializeObject<Note>(File.ReadAllText(GetFilePathById(id)));

            note.Edit(newText);

            File.WriteAllText(GetFilePathById(note.ID), JsonConvert.SerializeObject(note));
        }

        private string GetFilePathById(int id) => JsonFilesPath + id + ".json";


        public Note GetNote(int id)
        {
            // TODO: Getting note via JSON
            throw new NotImplementedException();
        }

        public IEnumerable<Note> GetNotes(bool orderedById)
        {
            // TODO: Getting all notes via JSON
            throw new NotImplementedException();
        }
    }
}
