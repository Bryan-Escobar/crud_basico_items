using login.Data;
using login.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace login.Controllers
{
    public class ItemsController : Controller
    {
        private readonly MyAppContext _context;
        public ItemsController(MyAppContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            //_context representa la base de datos
            var item=await _context.Items.ToListAsync();
            return View(item);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create([Bind("id,Name,Price")] Item item)
        {
            if(ModelState.IsValid)
            {
                _context.Add(item);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(item);
        }
        public async Task<IActionResult> Edit(int id)
        {
            var item = await _context.Items.FirstOrDefaultAsync(x => x.id == id);
            Console.WriteLine("item encontrador");
            Console.WriteLine(item.id + "," + item.Name + "," + item.Price);
            return View(item);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Price")] Item item)
        {
            item.id = id; //posible solucion
            Console.WriteLine("item a actualizar");
            Console.WriteLine(item.id+","+item.Name+","+item.Price);
           if(ModelState.IsValid)
            {

                _context.Update(item);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(item);
        }
        public async Task<IActionResult> Delete(int id)
        {
            var item=await _context.Items.FirstOrDefaultAsync(x => x.id == id);
            return View(item);
        }
        [HttpPost, ActionName("Delete")] //indica que aunque el metodo se llame diferente, sera una accion Delete
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var item=await _context.Items.FindAsync(id);
            if(item != null)
            {
                _context.Items.Remove(item);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction("Index");
        }
    }
}
