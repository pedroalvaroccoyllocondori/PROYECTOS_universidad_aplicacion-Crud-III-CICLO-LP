
create procedure nombrePreocedimiento 
as
select * from paises


create procedure insertar 
as
insert into paises values('enrique','lopez','001') 




exec nombrePreocedimiento 

 execute insertar
 drop proc insertar

 create procedure   insertar2
 @nombre varchar(50),
 @apellido varchar(50),
 @numero int
 as
 insert into paises values(@nombre,@apellido,@numero)
 exec insertar2 'juan','martines',985
 sp_help
 sp_depends insertar2


 create procedure prueba2
 @nombre varchar(50) ,
 @apellido varchar(50),
 @numero int output
 as
 set @numero =(select count(nombre) from paises where nombre=@nombre and apellido=@apellido)

 declare @total int
 exec prueba1  'enrique','lopez',@total output
 select @total as total
