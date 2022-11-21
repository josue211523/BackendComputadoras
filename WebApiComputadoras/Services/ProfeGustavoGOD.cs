namespace WebApiComputadoras.Services
{
    public class ProfeGustavoGOD: IHostedService
    {
        private readonly IWebHostEnvironment env;
        private readonly string archivoNom = "ProfeGOD.txt";
        private Timer timer;

        public ProfeGustavoGOD(IWebHostEnvironment env)
        {
            this.env = env;
        }

        private void Escribir(string msg)
        {
            var root = $@"{env.ContentRootPath}\wwwroot\{archivoNom}";
            using (StreamWriter sw = new StreamWriter(root, append: true))
            {
                sw.WriteLine(msg);
                sw.Close();
            }
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            timer = new Timer(DoWork, null, TimeSpan.Zero, TimeSpan.FromSeconds(120));
            Escribir("Se inicio el proceso");
            return Task.CompletedTask;
        }

        private void DoWork(object state)
        {
            Escribir("El Profe Gustavo Rodriguez es el mejor " + DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss"));
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            timer.Dispose();
            Escribir("Ha finalizado el proceso");
            return Task.CompletedTask;
        }

    }
}
