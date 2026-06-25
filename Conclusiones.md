### 9. Conclusiones

1. **Resolución de la Problemática Operativa:**
   El proyecto automatizó satisfactoriamente los procesos críticos de la Librería "Richard". Se logró transformar un flujo de trabajo basado íntegramente en listados físicos y cuadernos de anotación, a un aplicativo de software de escritorio que consolida el control de inventario y el registro de ventas. La digitalización eliminó las significativas pérdidas de tiempo asociadas a las consultas de precios (que sumaban hasta 160 minutos diarios en campaña) y sistematizó la facturación, reduciendo los tiempos de cierre de caja a menos de 1 minuto.

2. **Alineación con Criterios de Ingeniería (ABET):**
   La solución desarrollada demuestra el cumplimiento de los estándares de evaluación ABET al aplicar un enfoque estructurado para el análisis y resolución de problemas de ingeniería. Las limitantes técnicas diagnosticadas (como la fragilidad del algoritmo lineal de IDs en archivos planos y el riesgo de condiciones de carrera) y las medidas de protección implementadas (como el cifrado criptográfico AES sobre datos sensibles) evidencian la capacidad analítica del equipo para identificar riesgos, aplicar conocimiento técnico especializado y proponer arquitecturas fundamentadas que atienden la responsabilidad ética en el manejo de información.

3. **Mejoras Futuras Priorizadas y Escalabilidad:**
   Para garantizar el ciclo de vida del software y su viabilidad técnica a largo plazo, la máxima prioridad de mejora estructural consiste en migrar la capa de persistencia actual hacia un motor de Base de Datos Relacional (RDBMS) bajo un entorno Cliente-Servidor. Esta evolución tecnológica resolverá nativa y definitivamente los conflictos de concurrencia y gestión transaccional que enfrentan los dos encargados al operar simultáneamente sobre el mismo inventario, brindando la estabilidad necesaria para soportar un mayor volumen transaccional y la eventual apertura de nuevas sucursales.
