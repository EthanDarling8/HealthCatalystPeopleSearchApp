using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PeopleSearchApp.Models;

namespace PeopleSearchApp.Data {
    public class FileUploadBase : PageModel {
        private readonly PeopleSearchAppContext _context;
        private readonly IWebHostEnvironment _environment;

        public FileUploadBase() {
        }

        public FileUploadBase(IWebHostEnvironment hostEnvironment, PeopleSearchAppContext context) {
            _environment = hostEnvironment;
            _context = context;
        }

        /// <summary>
        ///     Uploads a file given a path string, and object representing a model, and a collection of files from a form.
        /// </summary>
        /// <param name="path"></param>
        /// <param name="obj"></param>
        /// <param name="formFiles"></param>
        /// <returns></returns>
        public async Task Upload(string path, object obj, IFormFileCollection formFiles) {
            var type = obj.GetType();

            foreach (var f in formFiles) {
                var file = f;
                var temp = file.FileName;
                var uploads = Path.Combine(_environment.WebRootPath, path);
                var fileName = Guid.NewGuid() + Path.GetExtension(file.FileName);
                await using (var fileStream = new FileStream(Path.Combine(uploads, fileName), FileMode.Create)) {
                    await file.CopyToAsync(fileStream);
                }

                // Person Image Upload
                if (type == typeof(Person)) {
                    var person = (Person) obj;
                    if (temp.Equals("")) {
                        person.Picture = "/" + path + "/" + "DefaultImage.png";
                        await _context.SaveChangesAsync();
                    }
                    else {
                        person.Picture = "/" + path + "/" + fileName;
                        await _context.SaveChangesAsync();
                    }

                    _context.Person.Update(person);
                }
            }
        }
    }
}