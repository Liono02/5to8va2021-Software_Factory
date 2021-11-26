/*Administrador: puede ver todo desde cualquier lado, dar de alta Proyectos, Tecnologías, Clientes y Empleados.
 También puede actualizar todo respecto a la tabla Proyecto.*/
SELECT 'Creando Usuarios' AS 'Estado' $$
drop user if exists 'Administrador'@'%';
create user 'Administrador'@'%' identified by 'PassAdministrador';
grant select on SoftwareFactory.* to 'Administrador'@'%';
grant insert,update on SoftwareFactory.Proyecto to 'Administrador'@'%';
grant insert on SoftwareFactory.Tecnologia to 'Administrador'@'%';
grant insert on SoftwareFactory.Cliente to 'Administrador'@'%';
grant insert on SoftwareFactory.Empleado to 'Administrador'@'%';

/*PM: desde la red 10.3.45.xxx puede
Ver todas las tablas.
Insertar (todo) y modificar (la calificación) de las Experiencias.
Dar de alta Empleados.
Insertar Requerimientos.
Insertar Tareas y modificar solo su fin.*/

drop user if exists 'Proyect_Manager'@'10.3.45.%';
create user 'Proyect_Manager'@'10.3.45.%' identified by 'PassProyect_Manager';
grant select on SoftwareFactory.* to 'Proyect_Manager'@'10.3.45.%';
grant insert,update(calificacion) on SoftwareFactory.Experiencia to 'Proyect_Manager'@'10.3.45.%';
grant insert on SoftwareFactory.Empleado to 'Proyect_Manager'@'10.3.45.%';
grant insert on SoftwareFactory.Requerimiento to 'Proyect_Manager'@'10.3.45.%';
