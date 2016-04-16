/// @file SimpleServiceInstaller.cs
/// @author Ron Wilson

using System.Diagnostics;
using System.ServiceProcess;
using System.ComponentModel;
using System.Configuration.Install;

namespace RPW.Simple
{
	[RunInstallerAttribute(true)]
	public class SimpleServiceInstaller : Installer
	{
		private ServiceInstaller m_serviceInstaller;
		private ServiceProcessInstaller m_processInstaller;

		private static string m_serviceName = Process.GetCurrentProcess().ProcessName;
		private static string m_displayName = Process.GetCurrentProcess().ProcessName;
		private static string m_servicePath = System.Reflection.Assembly.GetEntryAssembly().Location;

		public static string ServiceName
		{
			get
			{
				return m_serviceName;
			}
			set
			{
				m_serviceName = value;
			}
		}

		public static string ServicePath
		{
			get
			{
				return m_servicePath;
			}
			set
			{
				m_servicePath = value;
			}
		}

		public static string DisplayName
		{
			get
         {
         	return m_displayName;
         }
			set
			{
   			m_displayName = value;
			}
		}

		public SimpleServiceInstaller()
		{
			// setup and add the process installer
			m_processInstaller = new ServiceProcessInstaller()
				{
					Account = ServiceAccount.LocalSystem
				};
			Installers.Add(m_processInstaller);

			// setup and add the service installer
			m_serviceInstaller = new ServiceInstaller()
				{
					StartType = ServiceStartMode.Automatic,
					// ServiceName must equal those on ServiceBase derived classes.
					ServiceName = SimpleServiceInstaller.ServiceName,
					DisplayName = SimpleServiceInstaller.DisplayName,
					Description = SimpleServiceInstaller.ServicePath
				};
			Installers.Add(m_serviceInstaller);
		}
	}
}