namespace CrudApi.Entities
{
    public class Perfil
    {
        public int IdPerfil { get; set; }
        public string Nombre { get; set; }

        //Relacion para entre varios empledos con el Id del perfil
        public virtual  ICollection<Empleado> EmpleadoReferencia { get; set; }
    }
}