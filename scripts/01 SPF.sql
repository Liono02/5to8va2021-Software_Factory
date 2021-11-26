delimiter $$
/*Realizar los SP para dar de alta todas las tablas, menos la tabla Experiencia.*/
SELECT 'Creando Procesos' AS 'Estado' $$
create procedure AltaTecnologia(unIdTecnologia tinyint,unaTecnologia  varchar(20),unCostoBase decimal(10,2))
begin
	insert into Tecnologia(idTecnologia,tecnologia,costoBase)
    values(unIdTecnologia,unaTecnologia,unCostoBase);
end$$

create procedure AltaRequerimiento(unIdRequerimiento int,unIdProyecto smallint,unIdTecnologia int,unaDescripcion varchar(45),unaComplejidad tinyint)
begin
	insert into Requerimiento(idRequerimiento,idProyecto,idTecnologia,descripcion,complejidad)
    values(unIdRequerimiento,unIdProyecto,unIdTecnologia,unaDescripcion,unaCompejidad);
end$$

create procedure AltaProyecto(out unIdProyecto tinyint unsigned;unCuit int,unaDescripcion varchar(200),unPresupuesto decimal(10,2),unInicio date,unFin date)
begin
	insert into Proyecto(cuit,descripcion,presupuesto,inicio,fin)
    values(unCuit,unaDescripcion,unPresupuesto,unInicio,unFin);
    set unIdProyecto=LAST_INSERT_ID();
end$$

create procedure AltaTarea(unIdRequerimiento int,unCuil int,unInicio date,unFin date)
begin
	insert into Tarea(idRequerimiento,cuil,inicio,fin)
    values(unIdRequerimiento,unCuil,unInicio,unFin);
end$$

create procedure AltaCliente(unCuit int,unaRazonSocial varchar(50))
begin
	insert into Cliente(cuit,razonSocial)
    values(unCuit,unaRazonSocial);
end$$

create procedure AltaEmpleado(uncuil int,unNombre varchar(50),unApellido varchar(50),unaContratacion date)
begin
	insert into Empleado(cuil,nombre,apellido,contratacion)
    values(uncuil,unNombre,unApellido,unaContratacion);
end$$

/*Realizar el SP asignarExperiencia que recibe como parámetros cuil, idTecnologia y
una calificación. El SP tiene que crear un registro en caso de que no exista o
actualizarlo en caso de que si exista.*/
 
 create procedure AsignarExperiencia(unCuil int,unIdTecnologia tinyint,unaCalificacion tinyint)
 begin
    declare VerificarRegistro int;
    
    select count(cuil) into VerificarRegistro
    from Experiencia
    where cuil=unCuil
    and idTecnologia=unIdTecnologia;
    
    if(VerificarRegistro=1)then
        update Experiencia
        set calificacion=unaCalificacion
        where cuil=unCuil
        and idTecnologia=unIdTecnologia;
    end if;
    if(VerificarRegistro=0)then
        insert into Experiencia(cuil,idTecnologia,calificacion)
        values(unCuil,unIdTecnologia,unaCalificacion);
    end if;
end$$
 
/*Crear los SP finalizarTarea que reciba como parámetro un idRequerimiento, un cuil y
 una fecha de fin. El SP deberá actualizar la fecha de fin solamente si no tenía valor previo.*/
 
 create procedure FinalizarTarea(unIdRequerimiento int,unCuil int,unaFechaFin date)
 begin  
    update Tarea
    set fin=unaFechaFin
    where fin is null
    and idRequerimiento=unIdRequerimiento
    and cuil=unCuil;
end$$
 
create function ComplejidadPromedio(unIdProyecto smallint) returns float
begin
    declare PromedioComplejidad float;
    
    select avg(complejidad) into PromedioComplejidad
    from Requerimientos
    where idProyecto=unIdProyecto;
    
    return PromedioComplejidad;
end$$
 
/*Realizar la SF sueldoMensual que en base a un cuil devuelva el sueldo a pagar (DECIMAL (10,2))para el mes en curso.
SUELDO MENSUAL = Antigüedad en años * 1000 + SUMATORIA de (calificación de la exp. * costo base de la tecnología).*/
delimiter $$
SELECT 'Creando Funciones' AS 'Estado' $$
create function SueldoMensual(unCuil int)returns decimal(10,2)
begin
    declare sueldoMensual decimal(10,2);
    
    select  timestampdiff(year,contratacion,curdate())*1000 +
            Sum(calificacion*costoBase) into sueldoMensual
    from Empleado E
    inner join Experiencia using(cuil)
    inner join Tecnologia  on Experiencia.idTecnologia=Tecnologia.idTecnologia
    where E.cuil=unCuil;
    
    return sueldoMensual;
end$$
 
/*Realizar el SF costoProyecto que recibe como parámetro un idProyecto y devuelva el costo en DECIMAL (10,2).
COSTO PROYECTO = SUMATORIA (complejidad del requerimiento * costo base de la tecnología del Requerimiento).*/
delimiter $$
create function CostoProyecto(unIdProyecto int) returns decimal(10,2)
begin
    declare costoProyecto decimal(10,2);
    
    select sum(complejidad*costoBase) into costoProyecto
    from Requerimiento R
    inner join Tecnologia using(idTecnologia)
    where R.idProyecto=unIdProyecto;
    
    return costoProyecto;
end$$

delimiter $$
create Procedure ClientePorCuit(unCuit int)
begin
    Select *
    from Cliente
    where cuit=unCuit;
end$$