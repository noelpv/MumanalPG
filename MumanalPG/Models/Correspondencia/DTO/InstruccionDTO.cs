namespace MumanalPG.Models.Correspondencia.DTO
{
    public class InstruccionDTO
    {
        public string id { get; set; }
        public int funId { get; set; }
        public int areaId { get; set; }
        public int[] instrucciones { get; set; }
        public string comentarios { get; set; }
    }
}