using Anime_store.Enums;
using Anime_store.Exceptions;
using Anime_store.Helpers;
using Anime_store.Interfaces;
using Anime_store.Models;
using Microsoft.AspNetCore.Mvc;

namespace Anime_store.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnimeSeriesController : ControllerBase
    {
        private readonly IAnimeSeriesService _animeSeriesService;

        public AnimeSeriesController(IAnimeSeriesService animeSeriesService)
        {
            _animeSeriesService = animeSeriesService;
        }

        [HttpGet]
        public async Task<ActionResult<List<AnimeSeries>>> Get()
        {
            try
            {
                List<AnimeSeries> animes = await _animeSeriesService.GetAll();
                return Ok(animes);
            }
            catch (NoDataFoundException)
            {
                return NotFound();
            }
            catch (Exception)
            {
                return HttpResponseHelper.CustomStatusCode(EHttpStatus.INTERNAL_SERVER_ERROR);
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<AnimeSeries>> Get(int id)
        {
            try
            {
                AnimeSeries? anime = await _animeSeriesService.Get(id);
                if (anime == null)
                {
                    return NotFound();
                }
                return Ok(anime);
            }
            catch (NoDataFoundException)
            {
                return NotFound();
            }
            catch (Exception)
            {
                return HttpResponseHelper.CustomStatusCode(EHttpStatus.INTERNAL_SERVER_ERROR);
            }
        }

        [HttpPost]
        public async Task<ActionResult<AnimeSeries>> Post([FromBody] AnimeSeries anime)
        {
            try
            {
                await _animeSeriesService.Create(anime);
                return Ok(anime);
            }
            catch (FailedToCreateException<AnimeSeries>)
            {
                return BadRequest();
            }
            catch (Exception)
            {
                return HttpResponseHelper.CustomStatusCode(EHttpStatus.INTERNAL_SERVER_ERROR);
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<AnimeSeries>> Put(int id,[FromBody] AnimeSeries anime)
        {
            if (id != anime.Id)
            {
                return BadRequest();
            }

            try
            {
                await _animeSeriesService.Update(anime);
                return Ok(anime);
            }
            catch (NoDataFoundException)
            {
                return NotFound();
            }
            catch (FailedToUpdateException<AnimeSeries> ex)
            {
                return BadRequest(ex);
            }
            catch (Exception)
            {
                return HttpResponseHelper.CustomStatusCode(EHttpStatus.INTERNAL_SERVER_ERROR);
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<AnimeSeries>> Delete(int id)
        {
            try
            {
                await _animeSeriesService.Delete(id);
                return NoContent();
            }
            catch (NoDataFoundException)
            {
                return NotFound();
            }
            catch (Exception)
            {
                return HttpResponseHelper.CustomStatusCode(EHttpStatus.INTERNAL_SERVER_ERROR);
            }
        }
    }
}
