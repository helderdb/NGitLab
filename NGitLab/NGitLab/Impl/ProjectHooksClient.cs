using System.Collections.Generic;
using NGitLab.Models;

namespace NGitLab.Impl
{
    public class ProjectHooksClient : IProjectHooksClient
    {
        private readonly API _api;
        private readonly string _repoPath;
        private readonly string _projectPath;

        public ProjectHooksClient(API api, int projectId)
        {
            _api = api;

            _projectPath = Project.Url + "/" + projectId;
            _repoPath = _projectPath + "/hooks";
        }

        public IEnumerable<ProjectHook> All
        {
            get { return _api.Get().GetAll<ProjectHook>(_repoPath); }
        }

        public ProjectHook this[int hookId]
        {
            get { return _api.Get().To<ProjectHook>(_repoPath + "/" + hookId); }
        }

        public ProjectHook Create(ProjectHookUpsert hook)
        {
            return _api.Post().With(hook).To<ProjectHook>(_repoPath);
        }

        public ProjectHook Update(int hookId, ProjectHookUpsert hook)
        {
            return _api.Put().With(hook).To<ProjectHook>(_repoPath + "/" + hookId);
        }

        public void Delete(int hookId)
        {
            _api.Delete().To<ProjectHook>(_repoPath + "/" + hookId);
        }
    }
}