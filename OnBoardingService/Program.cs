using Infrastructure.Interfaces;
using Infrastructure.Repositories;
using SharedKernel.Interfaces;
using Topshelf;

namespace OnBoardingService
{
    public class Program
    {
        private static IOnBordingFormRepository? _onBordingFormRepository;
        private static IBaseDataAccess? _baseDataAccess;
      
        static void Main(string[] args)
        {
            Init();
            var exiCode = HostFactory.Run(host =>
            {
                host.Service<FormDueSectionNotifier>(service =>
                {
                    service.ConstructUsing(formDueSectionNotifier => new FormDueSectionNotifier(_onBordingFormRepository));
                    service.WhenStarted(formDueSectionNotifier => formDueSectionNotifier.Start());
                    service.WhenStopped(formDueSectionNotifier => formDueSectionNotifier.Stop());
                });

                host.SetServiceName("FormDueSectionNotifier");
                host.SetDisplayName("Form Due Section Notifier");
                host.RunAsLocalService();
            });

            var exitCodeValue = (int)Convert.ChangeType(exiCode, exiCode.GetTypeCode());
            Environment.Exit(exitCodeValue);
        }

        private static void Init()
        {
            if (_onBordingFormRepository is null)
            {
                _baseDataAccess = new BaseDataAccess("Data Source=mimir;Initial Catalog=OnBoarding; Persist Security Info=True;User ID=sa;Password=@cc3ss; MultipleActiveResultSets=True");
                _onBordingFormRepository = new OnBordingFormRepository(_baseDataAccess);
            }
        }
    }
}