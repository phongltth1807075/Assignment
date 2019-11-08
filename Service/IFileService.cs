using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using T1808AHelloUWP.Entity;

namespace T1808AHelloUWP.Service
{
    interface IFileService
    {
        Task<bool> SaveMemberCredentialToFile(MemberCredential memberCredential);

        Task<MemberCredential> ReadMemberCredentialFromFile();
    }
}
