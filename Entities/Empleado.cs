namespace CrudApi.Entities
{
    public class Empleado
    {   //Propiedades para conversion a tablas en SQL
        public int IdEmpleado { get; set;}
        public string NombreEmpleado { get; set;}
        public int Sueldo { get; set;}
        
        public int IdPerfil { get; set;}
        public virtual Perfil PerfilReferencia { get; set;}


    }
    
}