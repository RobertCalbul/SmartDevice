using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Resources;

// La información general sobre un ensamblado se controla mediante el siguiente
// conjunto de atributos. Cambie estos atributos para modificar la información
// asociada con un ensamblado.
[assembly: AssemblyTitle("LigthMeter")]
[assembly: AssemblyDescription("Capturador de datos")]
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyCompany("CODINER")]
[assembly: AssemblyProduct("LightMeter")]
[assembly: AssemblyCopyright("Copyright © Microsoft 2014")]
[assembly: AssemblyTrademark("LightMeter")]
[assembly: AssemblyCulture("")]

// Si establece ComVisible como false hace que los tipos de este ensamblado no sean visibles
// para los componentes COM. Si necesita obtener acceso a un tipo de este ensamblado desde
// COM, establezca el atributo ComVisible como true en este tipo.
[assembly: ComVisible(false)]

// El siguiente GUID sirve como identificador de typelib si este proyecto se expone a COM
[assembly: Guid("5e1d24ef-cd8f-486a-98a0-398288e14e15")]

// La información de versión de un ensamblado consta de los cuatro valores siguientes:
//
//      Versión principal
//      Versión secundaria
//      Número de versión de compilación
//      Revisión
//
[assembly: AssemblyVersion("3.14.0.0")]

// El atributo siguiente es para suprimir la advertencia sobre FxCop "CA2232 : Microsoft.Usage : Agregue STAThreadAttribute al ensamblado"
// como aplicación para dispositivos no admite el subproceso STA.
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2232:MarkWindowsFormsEntryPointsWithStaThread")]
[assembly: NeutralResourcesLanguageAttribute("es-CL")]
