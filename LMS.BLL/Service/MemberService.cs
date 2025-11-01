using LMS.BLL.Model;
using LMS.BLL.Repository;
using LMS.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.BLL.Service
{
    public class MemberService : IMemberService
    {
        MemberRepository _memberRepo = new MemberRepository();

        public async Task<List<MemberDTO>> GetAllMembers()
        {
            var members = await _memberRepo.GetAll(c => c.IsActive);
            var membersListDTO = new List<MemberDTO>();
            if (members == null)
                return membersListDTO;
            foreach (var member in members)
            {
                var memberDTO = new MemberDTO()
                {
                    Name = member.Name,
                    Email = member.Email,
                    MembershipDate = member.MembershipDate,
                    Phone = member.Phone,
                    CreatedOn = member.CreatedOn,
                    Id = member.Id,
                    IsActive = member.IsActive
                };
                membersListDTO.Add(memberDTO);
            }
            ;
            return membersListDTO;
        }

        public async Task<MemberDTO> GetMemberById(int memberId)
        {
            var member = await _memberRepo.GetBy(c => c.Id == memberId);
            if (member == null)
                return new MemberDTO();
            var memberDTO = new MemberDTO()
            {
                Name = member.Name,
                Email = member.Email,
                MembershipDate = member.MembershipDate,
                Phone = member.Phone,
                CreatedOn = member.CreatedOn,
                Id = member.Id,
                IsActive = member.IsActive
            };
            return memberDTO;
        }
        public async Task CreateMember(MemberDTO memberDTO)
        {
            var member = new Member()
            {
                Id = memberDTO.Id,
                Name = memberDTO.Name,
                Email = memberDTO.Email,
                MembershipDate = memberDTO.MembershipDate,
                Phone = memberDTO.Phone,
                CreatedOn = memberDTO.CreatedOn,
                IsActive = memberDTO.IsActive
                
            };
            await _memberRepo.CreateAsync(member);
        }
        public async Task UpdateMember(MemberDTO memberDTO)
        {
            var member = new Member()
            {
                Id = memberDTO.Id,
                Name = memberDTO.Name,
                Email = memberDTO.Email,
                MembershipDate = memberDTO.MembershipDate,
                Phone = memberDTO.Phone,
                CreatedOn = memberDTO.CreatedOn,
                IsActive = memberDTO.IsActive

            };
            await _memberRepo.UpdateAsync(member);
        }
        public async Task DeleteMember(MemberDTO memberDTO)
        {
            var member = new Member()
            {
                Id = memberDTO.Id,
                Name = memberDTO.Name,
                Email = memberDTO.Email,
                MembershipDate = memberDTO.MembershipDate,
                Phone = memberDTO.Phone,
                CreatedOn = memberDTO.CreatedOn,
                IsActive = memberDTO.IsActive

            };
            await _memberRepo.DeleteAsync(member);
        }
        public async Task<(Member?, List<BorrowTransaction>, List<ReservationTransaction>)> ViewProfile(int memberId)
        {
            var memberProfile = await _memberRepo.ViewProfile(memberId);
            return memberProfile;
        }
    }
    public interface IMemberService
    {
        Task<List<MemberDTO>> GetAllMembers();
        Task<MemberDTO> GetMemberById(int memberId);
        Task CreateMember(MemberDTO memberDTO);
        Task UpdateMember(MemberDTO memberDTO);
        Task DeleteMember(MemberDTO memberDTO);
        Task<(Member?, List<BorrowTransaction>, List<ReservationTransaction>)> ViewProfile(int memberId);
    }
}
