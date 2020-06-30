using LibGit2Sharp;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SoftplanRule
{
    public class RepositoryInformation : IDisposable, IRepositoryInformation
    {
        public static RepositoryInformation GetRepositoryInformationForPath(string path)
        {
            if (Repository.IsValid(path))
            {
                return new RepositoryInformation(path);
            }
            return null;
        }

        public string CommitHash
        {
            get
            {
                return _repo.Head.Tip.Sha;
            }
        }

        public string BranchName
        {
            get
            {
                return _repo.Head.RemoteName;
            }
        }

        public string TrackedBranchName
        {
            get
            {
                return _repo.Head.IsTracking ? _repo.Head.TrackedBranch.RemoteName : string.Empty;
            }
        }

        public bool HasUnpushedCommits
        {
            get
            {
                return _repo.Head.TrackingDetails.AheadBy > 0;
            }
        }

        public bool HasUncommittedChanges
        {
            get
            {
                return _repo.RetrieveStatus().Any(s => s.State != FileStatus.Ignored);
            }
        }

        public string Url
        {
            get
            {
                return _repo.Network.Remotes.FirstOrDefault().Url;
            }
        }

        public IEnumerable<Commit> Log
        {
            get
            {
                return _repo.Head.Commits;
            }
        }

        public void Dispose()
        {
            if (!_disposed)
            {
                _disposed = true;
                _repo.Dispose();
            }
        }

        private RepositoryInformation(string path)
        {
            _repo = new Repository(path);
        }

        private bool _disposed;
        private readonly Repository _repo;
    }
}
