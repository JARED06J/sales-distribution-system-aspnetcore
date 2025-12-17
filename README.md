# Sistema de Ventas y Distribución – ASP.NET Core MVC

## 📌 Descripción

Proyecto desarrollado en **ASP.NET Core MVC** que implementa un **Sistema de Ventas y Distribución**, orientado a la gestión de productos, proveedores, compras y control básico de operaciones.

El sistema fue construido como un proyecto académico avanzado, aplicando buenas prácticas de **arquitectura backend**, separación de responsabilidades y lógica de negocio.

Este repositorio representa un proyecto **real y funcional**, no un ejemplo básico.

---

## 🛠️ Tecnologías utilizadas

* **C#**
* **ASP.NET Core MVC**
* **.NET 9
* **Entity Framework Core**
* **SQL Server**
* **HTML / Razor Views**
* **Bootstrap** (para estilos básicos)

---

## 🧱 Arquitectura del proyecto

El proyecto sigue el patrón **MVC (Model–View–Controller)** y está organizado de la siguiente manera:

* **Controllers**: Manejan las peticiones HTTP y la interacción con la vista.
* **Models**: Representan las entidades y estructuras de datos.
* **Services**: Contienen la lógica de negocio y reglas del sistema.
* **Helpers**: Funciones auxiliares reutilizables.
* **Views**: Interfaz de usuario (Razor Views).
* **wwwroot**: Archivos estáticos (CSS, JS, imágenes).

Esta estructura facilita el mantenimiento, escalabilidad y pruebas del sistema.

---

## ▶️ Cómo ejecutar el proyecto

1. Clonar el repositorio:

```bash
git clone https://github.com/tu-usuario/tu-repositorio.git
```

2. Abrir el proyecto en **Visual Studio 2022**.

3. Configurar la cadena de conexión en `appsettings.json`:

```json
"ConnectionStrings": {
  "DefaultConnection": "Server=TU_SERVIDOR;Database=TU_BD;Trusted_Connection=True;"
}
```

4. Restaurar paquetes NuGet.

5. Ejecutar el proyecto (`Ctrl + F5`).

---

## 🎯 Funcionalidades principales

* Gestión de productos
* Gestión de proveedores
* Registro de compras
* Listado y visualización de información
* Separación clara entre lógica de negocio y presentación

---

## 📚 Qué aprendí con este proyecto

* Diseño de aplicaciones web con **ASP.NET Core MVC**
* Organización de proyectos backend profesionales
* Uso de **servicios** para encapsular lógica de negocio
* Integración con **SQL Server**
* Buenas prácticas para proyectos publicables en GitHub

---

## 👨‍💻 Autor

Desarrollado por **Jared Garbanzo**
Perfil orientado a **Backend / Software Developer (.NET)**

---

## 📎 Notas

Este proyecto forma parte de mi portafolio profesional y demuestra mi capacidad para desarrollar aplicaciones backend estructuradas y funcionales.
