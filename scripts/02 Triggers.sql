/*Antes de hacer un Insert en Tarea,
 si la calificación del empleado es menor a la complejidad del requerimiento no se tiene que permitir el Insert y
  se tiene que mostrar la leyenda "Calificación insuficiente".*/

DELIMITER $$
SELECT 'Creando Triggers' AS 'Estado' $$
drop trigger if exists VerificarComplejidad $$
create trigger VerificarComplejidad  before insert on Tarea
for each row
begin
	  declare RangoExperiencia tinyint;
      declare RangoComplejidad tinyint;
      
      select calificacion,complejidad into RangoExperiencia,RangoComplejidad
      from Experiencia
      inner join Requerimiento on Experiencia.idTecnologia=Requerimiento.idTecnologia
      where cuil=new.cuil
      and idRequerimiento=new.idRequerimiento;
      
      if(RangoExperiencia<RangoComplejidad)then
		signal sqlstate '45000'
        set message_text='Calificación del CUIL insuficiente';
        
	  end if;
end$$

delimiter $$
/*Realizar un trigger para que al ingresar un usuario,
 le asigne por defecto experiencia en todas las tecnologías disponibles con calificación igual a CERO.*/
 create trigger ExperienciaDefault after insert on Empleado
 for each row
 begin
	insert into Experiencia(cuil,idTecnologia,calificacion)
    select (new.cuil,Tecnologia.idTecnologia,0)
    from Tecnologia;
end$$
