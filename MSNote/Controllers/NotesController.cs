﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MSNote.Model;
using MSNote.Services;

namespace MSNote.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotesController : ControllerBase
    {
        private readonly NotesService _notesService;

        public NotesController(NotesService notesService) =>
       _notesService = notesService;

        [HttpGet]
        public async Task<List<Note>> Get() =>
            await _notesService.GetAsync();

        //[HttpGet("{id:length(24)}")]
        //public async Task<ActionResult<Note>> Get(string id)
        //{
        //    var note = await _notesService.GetAsync(id);

        //    if (note is null)
        //    {
        //        return NotFound();
        //    }

        //    return note;
        //}

        [HttpGet("{patId}")]
        public async Task<ActionResult<Note>> Get(int patId)
        {
            var note = await _notesService.GetAsync(patId);

            if (note is null)
            {
                return NotFound();
            }

            return note;
        }

        [HttpPost]
        public async Task<IActionResult> Post(Note newNote)
        {
            await _notesService.CreateAsync(newNote);

            return CreatedAtAction(nameof(Get), new { id = newNote.Id }, newNote);
        }

        //[HttpPut("{id:length(24)}")]
        //public async Task<IActionResult> Update(string id, Note updatedBook)
        //{
        //    var book = await _notesService.GetAsync(id);

        //    if (book is null)
        //    {
        //        return NotFound();
        //    }

        //    updatedBook.Id = book.Id;

        //    await _notesService.UpdateAsync(id, updatedBook);

        //    return NoContent();
        //}

        //[HttpDelete("{id:length(24)}")]
        //public async Task<IActionResult> Delete(string id)
        //{
        //    var book = await _notesService.GetAsync(id);

        //    if (book is null)
        //    {
        //        return NotFound();
        //    }

        //    await _notesService.RemoveAsync(id);

        //    return NoContent();
        //}
    }
}

