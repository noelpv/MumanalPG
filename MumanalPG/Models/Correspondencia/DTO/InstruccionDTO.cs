namespace MumanalPG.Models.Correspondencia.DTO
{
    public class InstruccionDTO
    {
        public string id { get; set; }
        public int funDstId { get; set; }
        public int[] instrucciones { get; set; }
        public string comentarios { get; set; }
    }
}