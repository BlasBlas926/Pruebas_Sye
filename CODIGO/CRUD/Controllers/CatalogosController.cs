using System.Security.Cryptography.X509Certificates;
using Microsoft.AspNetCore.Mvc;



namespace Catalogos.Controllers
{

    public class CatalogosController : Controller
    {
        private HttpClient httpClient;

        public CatalogosController(IHttpClientFactory httpClientFactory)
        {
            httpClient = httpClientFactory.CreateClient();
            httpClient.BaseAddress = new Uri("http://localhost:5074");
            httpClient.DefaultRequestHeaders.Accept.Clear();
            httpClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("aplication/json"));

        }

        public async Task<IActionResult> Index()
        {
            var respuesta = await httpClient.GetAsync("/api/Catalogos");
            if (respuesta.IsSuccessStatusCode)
            {
                var catalogos = await respuesta.Content.ReadAsAsync<List<Catalogos>>();
                return View(catalogos);
            }
            else
            {
                return View("Error");
            }
        }
        public async Task<IActionResult> Details(string id)
        {
            var respuesta = await httpClient.GetAsync($"/api/Catalogos/{id}");
            if (respuesta.IsSuccessStatusCode)
            {

                var catalogos = await respuesta.Content.ReadAsAsync<Catalogos>();
                return View(catalogos);
            }
            else
            {
                return View("Error");
            }

        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Catalogos catalogosDTO)
        {
            var respuesta = await httpClient.PostAsJsonAsync("/api/Catalogos", catalogosDTO);
            if (respuesta.IsSuccessStatusCode)
            {


                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View("Error");
            }
        }


        public async Task<IActionResult> Edit(string id)
        {
             var respuesta = await httpClient.GetAsync($"/api/Catalogos/{id}");
            if (respuesta.IsSuccessStatusCode)
            {

                var catalogos = await respuesta.Content.ReadAsAsync<Catalogos>();
                return View(catalogos);
            }
            else
            {
                return View("Error");
            }
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, string descripcion)
        {
            
            var respuesta = await httpClient.PatchAsJsonAsync($"/api/Catalogos/{id}", descripcion);

            if (respuesta.IsSuccessStatusCode)
            {
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View("Error"); 
            }
        }


        public async Task<IActionResult> Delete(string id)
        {
            var respuesta = await httpClient.GetAsync($"/api/Catalogos/{id}");
            if (respuesta.IsSuccessStatusCode)
            {

                var catalogos = await respuesta.Content.ReadAsAsync<Catalogos>();
                return View(catalogos);
            }
            else
            {
                return View("Error");
            }

        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var respuesta = await httpClient.DeleteAsync($"/api/Catalogos/{id}");
            if (respuesta.IsSuccessStatusCode)
            {

                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View("Error");
            }
        }
    }
}