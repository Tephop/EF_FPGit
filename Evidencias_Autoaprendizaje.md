### 8.1. Bitácora de Aprendizaje Autodirigido
Durante el ciclo de desarrollo, el equipo identificó requerimientos técnicos que excedían los temas básicos vistos en clase. A continuación, se detalla la bitácora de autoaprendizaje que permitió superar estas brechas y construir una solución robusta:

*   **Fecha:** 20 de mayo de 2026
    *   **Brecha Técnica:** Necesidad de persistir la información del inventario (Productos, Proveedores, Ventas) localmente en memoria no volátil, dado que el uso exclusivo de listas resultaba en la pérdida de datos al cerrar la aplicación.
    *   **Acción de Aprendizaje:** Investigación de la documentación oficial de Microsoft sobre manipulación de flujos de texto (Text I/O) en C#.
    *   **Resultado Aplicado:** Implementación exitosa de la clase estática `ArchivoHelper.cs` haciendo uso intensivo de los objetos `StreamWriter` y `StreamReader` para la lectura y escritura de entidades, delimitadas por barras verticales (`|`), en archivos de texto plano.

*   **Fecha:** 02 de junio de 2026
    *   **Brecha Técnica:** Identificación de errores de usuario en el registro de proveedores (específicamente en el formato del correo electrónico), lo cual podría afectar futuras comunicaciones o envíos de comprobantes.
    *   **Acción de Aprendizaje:** Búsqueda de una validación estructurada y robusta para direcciones de correo, con el fin de evitar el uso de expresiones regulares complejas y propensas a fallos (Regex).
    *   **Resultado Aplicado:** Integración de la clase `MailAddress` del espacio de nombres `System.Net.Mail`. Al instanciar este objeto con el input del usuario, el sistema puede capturar la excepción (`FormatException`) y rechazar la entrada automáticamente si el formato es inválido.

*   **Fecha:** 24 de junio de 2026
    *   **Brecha Técnica:** Elevado riesgo de exposición de datos personales sensibles (Teléfono, Correo, Dirección) al almacenar la base de datos `proveedores.txt` en el Escritorio público y en texto plano.
    *   **Acción de Aprendizaje:** Estudio de los algoritmos de criptografía simétrica provistos de forma nativa por el framework de .NET (`System.Security.Cryptography`).
    *   **Resultado Aplicado:** Desarrollo de los métodos de seguridad `Encrypt` y `Decrypt` dentro de `ArchivoHelper.cs` utilizando el estándar de la industria `Aes` (Advanced Encryption Standard). Los datos ahora se transforman y almacenan en disco cifrados en Base64. Adicionalmente, se protegió la ruta de almacenamiento migrándola a la carpeta aislada `LocalApplicationData`.

### 8.2. Referencias Bibliográficas de las Clases Utilizadas
Para el desarrollo de las soluciones mencionadas en la bitácora, se consultó exclusivamente documentación técnica oficial de Microsoft:

1. **Manipulación de Archivos (`System.IO`):**
   *Microsoft (2024). StreamWriter Class (System.IO).* Recuperado de: https://learn.microsoft.com/es-es/dotnet/api/system.io.streamwriter
   *Microsoft (2024). StreamReader Class (System.IO).* Recuperado de: https://learn.microsoft.com/es-es/dotnet/api/system.io.streamreader

2. **Validación de Correos Electrónicos (`System.Net.Mail`):**
   *Microsoft (2024). MailAddress Class (System.Net.Mail).* Recuperado de: https://learn.microsoft.com/es-es/dotnet/api/system.net.mail.mailaddress

3. **Criptografía y Cifrado Simétrico (`System.Security.Cryptography`):**
   *Microsoft (2024). Aes Class (System.Security.Cryptography).* Recuperado de: https://learn.microsoft.com/es-es/dotnet/api/system.security.cryptography.aes
   *Microsoft (2024). Modelo de criptografía de .NET.* Recuperado de: https://learn.microsoft.com/es-es/dotnet/standard/security/cryptography-model

### 8.3. Evidencias de Implementación ("Antes y Después")
Como prueba tangible de la investigación y mejora continua aplicada sobre la mitigación de riesgos de seguridad de datos (referenciada en la bitácora del 24 de junio), se presentan a continuación las capturas de la base de datos `proveedores.txt`.

**[PLACEHOLDER: Pega aquí la captura de pantalla o el texto directamente del archivo "proveedores_antes.txt" que generamos en el paso anterior]**
*Figura 1: Estado Anterior (Brecha de Seguridad). Los datos sensibles de contacto de los proveedores (teléfono, correo, dirección) se almacenaban y exponían en texto plano legible.*

**[PLACEHOLDER: Pega aquí la captura de pantalla o el texto directamente del archivo "proveedores_despues.txt" que generamos en el paso anterior]**
*Figura 2: Estado Posterior (Mejora Aplicada). Implementación exitosa del cifrado AES. Nótese que los tres últimos campos correspondientes a la información personal están ofuscados e ilegibles, protegiendo la privacidad de los proveedores ante un acceso físico no autorizado al archivo.*
