namespace MumanalPG.Utility
{
    public class Constantes
    {
        public const int TamanoPaginacion = 5;
        public const int Registrado = 0;
        public const int Aprobado = 1;
        public const int Anulado = 2;
        public const int Revertido = 3;
        public const int Devuelto = 4;
        public const int Enviado = 5;
        public const int Archivado = 6;
        public const int Desaprobado = 7;
        public const int Desarchivado = 8;
        public const int Recepcionado = 9;
        
        /*Acciones guardar, modificar y eliminar*/
        public const string Creado = "created";
        public const string Modificado = "modified";
        public const string Eliminado = "deleted";

        public const string HojaRutaInterna = "INTERNA";
        public const string HojaRutaExterna = "EXTERNA";
        public const string PrioridadUrgente = "URGENTE";
        public const string PrioridadAlta = "ALTA";
        public const string PrioridadMedia = "MEDIA";
        public const string PrioridadBaja = "BAJA";
        public const string HRTipoRecibidos = "received";
        public const string HRTipoUrgentes = "urgent";
        public const string HRTipoDespachados = "sent";
        public const string HRTipoArchivados = "archived";
        public const string HRTipoEliminados = "removed";
    }
}