namespace Pineapple.Portal.Models;

public class NoteResponseDto
{
    public List<NoteEntity> Docs { get; set; } = new List<NoteEntity>();
    public int TotalDocs { get; set; }
}
