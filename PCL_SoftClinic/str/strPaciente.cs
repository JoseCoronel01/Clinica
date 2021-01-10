namespace PCL_SoftClinic.str
{
    public class strPaciente
    {
        public long Id { get; set; }
        public string ApellidoPaterno { get; set; }
        public string ApellidoMaterno { get; set; }
        public string Nombre { get; set; }
        public string TelContacto { get; set; }
        public string Responsable { get; set; }
        public string LugarResidencia { get; set; }
        public eEstatus Estatus { get; set; }
        public eTipo TipoTratamiento { get; set; }
        public enum eEstatus
        {
            SINESTATUS=0,ACTIVO=1,INACTIVO=2,BAJA=3
        }
        public enum eTipo
        {
            SINTIPO=0,ETAPA_EXPERIMENTAL=1,SEGUIMIENTO_DE_TRATAMIENTO=2,PREVENCION_DE_RECAIDAS=3
        }
        public override string ToString()
        {
            return this.ApellidoPaterno + " " + this.ApellidoMaterno + " " + this.Nombre;
        }
    }
}