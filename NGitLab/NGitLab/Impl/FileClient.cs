using NGitLab.Models;

namespace NGitLab.Impl
{
    public class FileClient : IFilesClient
    {
        private readonly API _api;
        private readonly string _repoPath;
        private readonly string _projectPath;

        public FileClient(API api, int projectId)
        {
            _api = api;

            _projectPath = Project.Url + "/" + projectId;
            _repoPath = _projectPath + "/repository";
        }

        public void Create(FileUpsert file)
        {
            _api.Post().With(file).Stream(_repoPath + "/files", s => { });
        }

        public void Update(FileUpsert file)
        {
            _api.Put().With(file).Stream(_repoPath + "/files", s => { });
        }

        public void Delete(FileDelete file)
        {
            _api.Delete().With(file).Stream(_repoPath + "/files", s => { });
        }
    }
}