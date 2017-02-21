/*
Descripcion:Programa que se autoreplica, utilizando un truco con la syscall sendfile la cual pasa directamente el
descriptor del archivo  en vez de leer y escribir los bytes, lo cual hace mucho más rapido la copia.  
Autor:d4sh&r

*/
#include <fcntl.h>
#include <sys/sendfile.h>
#include <sys/stat.h>
#include <sys/types.h>
#include <unistd.h>

int main (int argc, char* argv[])
{

char * progname=argv[0];
int read_fd;
int write_fd;
struct stat stat_buf;
off_t offset = 0;

write(1, "creado por d4sh&r\n", 18);
/*Abre el archivo en solo lectura*/
read_fd = open (progname, O_RDONLY);
/*fstat regresa una estructura donde uno de sus campos es el tamaño*/
fstat (read_fd, &stat_buf);
/*Abre el archivo en modo escritura con los mismos permisos que el original*/
write_fd = open ("copia", O_WRONLY | O_CREAT, stat_buf.st_mode);
/*Envia los bytes de un archivo a otro*/
sendfile (write_fd, read_fd, &offset, stat_buf.st_size);
/*Cerrar los archivos*/
close (read_fd);
close (write_fd);
return 0;
}
