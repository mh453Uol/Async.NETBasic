using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Async.NETBasic.Models;
using AsyncConsoleApp;

namespace Async.NETBasic.Controllers
{
    public class HomeController : Controller
    {
        private PersonRepository personRepository = new PersonRepository();

        public IActionResult Index()
        {
            Stopwatch watch = new Stopwatch();
            watch.Start();
            ContentManagement service = new ContentManagement();
            var content = service.GetContent(); //2 sec
            var count = service.GetCount(); //5 sec
            var name = service.GetName(); //3
            watch.Stop();
            // Total is 10sec since operations happen one after another
            ViewBag.WatchMillisecond = watch.ElapsedMilliseconds;
            return View();
        }

        public async Task<IActionResult> IndexAsync()
        {
            Stopwatch watch = new Stopwatch();
            watch.Start();
            ContentManagement service = new ContentManagement();
            //These happen all at once longest operation is 5 seconds
            var contentTask = service.GetContentAsync();
            var countTask = service.GetCountAsync();
            var nameTask = service.GetNameAsync();

            var content = await contentTask;
            var count = await countTask;
            var name = await nameTask;
            watch.Stop();
            //Total time is 5 seconds since all start at once the longest is 5 second so its finished last
            ViewBag.WatchMillisecond = watch.ElapsedMilliseconds;
            return View("Index");
        }

        public async Task<IActionResult> People()
        {
            Task<List<Person>> people = personRepository.GetAsync();
            //Once GetAsync is done then sort ..
            await people.ContinueWith(Sort);

            ViewBag.People = people.Result;
            return View("People");
        }

        public void Sort(Task<List<Person>> people)
        {
            people.Result.OrderByDescending(p => p.DateOfBirth);
        }
    }

}
