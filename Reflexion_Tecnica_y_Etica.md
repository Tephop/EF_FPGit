### 7.1. Beneficio para el Usuario y la Librería "Richard"
La implementación de este sistema representa un salto cualitativo en la eficiencia operativa de la Librería "Richard", mitigando los cuellos de botella identificados durante las temporadas de alta demanda (como la campaña escolar). Según los datos levantados inicialmente, los dos encargados perdían en conjunto hasta 160 minutos diarios buscando precios en cuadernos y listados físicos. Además, el proceso manual de cierre de caja tomaba entre 15 y 20 minutos debido al recuento y consolidación en papel. Con la automatización introducida por el sistema, la consulta de precios se vuelve instantánea y centralizada, reduciendo el tiempo de búsqueda a cero. Asimismo, el arqueo de caja se consolida de forma automática en menos de 1 minuto, emitiendo un reporte exacto de las ventas y permitiendo a los dueños enfocar ese valioso tiempo en la atención al cliente y la reposición de mercadería.

### 7.2. Manejo y Protección de Datos Personales
El sistema recopila y maneja datos personales y de contacto sensibles en el módulo de proveedores, específicamente: **Teléfono, Correo Electrónico y Dirección**. Reconociendo la responsabilidad ética y legal que implica el almacenamiento de esta información, se implementó una estrategia activa de **mitigación de riesgo de datos**.
En primer lugar, los archivos de almacenamiento físico se migraron del Escritorio público a la carpeta protegida `LocalApplicationData` del sistema operativo, evitando la exposición accidental o robo de datos a través de servicios de sincronización en la nube no configurados. En segundo lugar, se aplicó un cifrado **AES (Advanced Encryption Standard)** a los campos sensibles mencionados antes de persistirlos en el archivo `proveedores.txt`. Esto asegura que si una entidad no autorizada logra acceder al archivo físico, los datos de contacto serán ilegibles. *(Nota: Como limitación técnica conocida para esta versión, se empleó una clave simétrica embebida en el código fuente, la cual representa un riesgo documentado que deberá externalizarse en iteraciones futuras).*

### 7.3. Limitación Técnica del Sistema (Perspectiva ABET)
Desde una perspectiva de ingeniería y arquitectura de software, una limitación concreta y crítica de la solución actual recae en el **algoritmo de generación de identificadores (IDs) y la gestión de la concurrencia**. Actualmente, el sistema lee el último ID de un archivo de texto plano y genera el correlativo de forma lineal en memoria. Este enfoque es estructuralmente frágil y carece de soporte para entornos **multiusuario**. Dado que la librería cuenta con dos encargados que muy probablemente operarán el sistema de forma simultánea en múltiples terminales durante la campaña escolar, existe un alto riesgo de *condiciones de carrera* (race conditions). Si ambos intentan registrar un producto o una venta al mismo tiempo, el sistema generará colisiones de IDs (IDs duplicados) o sobrescribirá datos simultáneamente, corrompiendo irreversiblemente los archivos planos.

### 7.4. Mejora Estructural Futura (Perspectiva ABET)
Para resolver la limitación descrita, la mejora estructural fundamental para la siguiente versión es **migrar la capa de persistencia de archivos planos a una arquitectura Cliente-Servidor respaldada por un Motor de Base de Datos Relacional** (tales como SQLite, MySQL o SQL Server).
Esta actualización tecnológica solucionará el problema de raíz al delegar el control de concurrencia y la generación de claves únicas (mediante `PRIMARY KEY AUTOINCREMENT` o `IDENTITY`) directamente al motor de base de datos. La adopción de transacciones con cumplimiento ACID (Atomicidad, Consistencia, Aislamiento, Durabilidad) garantizará que cuando los dos encargados ejecuten operaciones simultáneas sobre el mismo inventario, la base de datos gestione los bloqueos de escritura (locks) de manera transparente y segura, eliminando por completo el riesgo de corrupción de datos y preparando el software para la escalabilidad.

### 7.5. Reflexiones Individuales de Aprendizaje

**Aguilar Jiménez:**
[PLACEHOLDER - Aguilar Jiménez: Describir aquí los aprendizajes técnicos, dificultades superadas y reflexiones éticas obtenidas durante el desarrollo del proyecto. (Aprox. 3-4 líneas)]

**Armas Camones:**
[PLACEHOLDER - Armas Camones: Describir aquí los aprendizajes técnicos, dificultades superadas y reflexiones éticas obtenidas durante el desarrollo del proyecto. (Aprox. 3-4 líneas)]

**Carrasco Lévano:**
[PLACEHOLDER - Carrasco Lévano: Describir aquí los aprendizajes técnicos, dificultades superadas y reflexiones éticas obtenidas durante el desarrollo del proyecto. (Aprox. 3-4 líneas)]

**Dagnino Bringas:**
[PLACEHOLDER - Dagnino Bringas: Describir aquí los aprendizajes técnicos, dificultades superadas y reflexiones éticas obtenidas durante el desarrollo del proyecto. (Aprox. 3-4 líneas)]

**García Martínez:**
[PLACEHOLDER - García Martínez: Describir aquí los aprendizajes técnicos, dificultades superadas y reflexiones éticas obtenidas durante el desarrollo del proyecto. (Aprox. 3-4 líneas)]
