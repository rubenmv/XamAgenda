# XamAgenda 
Esta es una pequeña aplicación desarrollada con Xamarin Forms que sirve de aprendizaje de esta plataforma de desarrollo para móviles. 

Agenda personal para guardar contactos y citas. 

Proyecto se ha realizado en Visual Studio 2017. 

## Características del proyecto 
- Uso de **Xamarin Forms** (Multiplataforma).
- Proyecto tipo **PCL**. Se compila en una librería portable DLL.
- Patrón de navegación Master Detail.
- Aplicación de patrones del tipo Model-View-ViewModel, Command y Observer.
- Data Binding en doble sentido.
- Uso de SQLite para guardar la información de manera local.

## TODO 
- [x] Login de usuario.
- [x] Lista de contactos.
- [x] Detalles de contactos.
- [x] Búsqueda de contactos.
- [x] Página de detalle de contacto.
- [x] Modificación de los datos del usuario/contacto.
- [ ] Lista de citas/eventos.
- [x] !! Almacenamiento de datos de manera local mediante SQLite.
	NOTA: la funcionalidad de usar SQLite esta ahí pero no se usa ya que SQLite.Net reconoce solo una
	serie de tipos de datos, por lo que no se puede tener una lista de <Contact> en un User. Habría que
		usar índices y eso requiere reescribir muchas cosas.
- [ ] Almacenamiento de datos de manera remota mediante web services.
- [ ] Crash al volver a la pagina principal usando los botones del telefono. Debería volver a la pagina de detalles del usuario.

## Capturas de pantalla 

### Login 
<img src="screenshot_1.png" width="300"> 

### Registro de nuevo usuario 
<img src="screenshot_2.png" width="300"> 

### Pantalla principal de los datos del usuario 
<img src="screenshot_3.png" width="300"> 

### Lista de contactos 
<img src="screenshot_4.png" width="300"> 

### About 
<img src="screenshot_5.png" width="300"> 
