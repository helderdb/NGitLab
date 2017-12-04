using System.Collections.Generic;
using NGitLab.Models;

namespace NGitLab.Impl
{
    public class BranchClient : IBranchClient
    {
        private readonly API _api;
        private readonly string _repoPath;
        private readonly string _projectPath;

        public BranchClient(API api, int projectId)
        {
            _api = api;
            
            _projectPath = Project.Url + "/" + projectId;
            _repoPath = _projectPath + "/repository";
        }

        public IEnumerable<Branch> All
        {
            get { return _api.Get().GetAll<Branch>(_repoPath + "/branches"); }
        }
            
        public Branch this[string name]
        {
            get { return _api.Get().To<Branch>(_repoPath + "/branches/" + name); }
        }

        public Branch Protect(string name)
        {
            return _api.Put().To<Branch>(_repoPath + "/branches/" + name + "/protect");
        }

        public Branch Unprotect(string name)
        {
            return _api.Put().To<Branch>(_repoPath + "/branches/" + name + "/unprotect");
        }

        public Branch Create(BranchCreate branch)
        {
            return _api.Post().With(branch).To<Branch>(_repoPath + "/branches");
        }

        public BranchRemovalStatus Delete(string name)
        {
            var errorMessage = _api.Delete().To<string>(_repoPath + "/branches/" + name);
            return BranchRemovalStatus.FromReponseMessage(errorMessage);
        }
    }
}