namespace NewWorkWhisperAPI.Models
{
    public class WhisperModel
    {
        public int WhisperId { get; set; }  
        public int SquadId { get; set; }
        public int UserId { get; set; }
        public string WhisperContent { get; set; }
        public int WhisperTypeWtypeId { get; set; }
        public int WhisperTopicWtopicId { get; set; }
    }

}
