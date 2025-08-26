using MarsAdvancedTaskPart1.Framework.Models;
using NUnit.Framework;

namespace MarsAdvancedTaskPart1.Framework.Helpers
{
    public static class TestDataProvider
    {
        public static IEnumerable<TestCaseData> ChangePasswordData()
        {
            var data = JsonHelper.ReadJson<ChangePasswordModel>("TestData/ChangePasswordTestData.json");
            yield return new TestCaseData(data).SetName($"ChangePasswordTest_{data.CurrentPassword}_{data.ExpectedMessage}");
        }

        public static IEnumerable<TestCaseData> AccountSettingsData()
        {
            var data = JsonHelper.ReadJson<AccountSettingsModel>("TestData/AccountSettingsTestData.json");
            yield return new TestCaseData(data).SetName($"AccountSettingsTest_Name_{data.Name}_Password_{data.Password?.ExpectedMessage}");
        }

        public static IEnumerable<TestCaseData> ChatData()
        {
            var data = JsonHelper.ReadJson<ChatModel>("TestData/ChatTestData.json");
            yield return new TestCaseData(data).SetName($"ChatTest_{data.ExpectedMessageForChat}");
        }

        //Languages data provider methods

        public static IEnumerable<TestCaseData> AddLanguagesValidData()
        {
            var languageModel = JsonHelper.ReadJson<LanguageModel>("TestData/AddLanguages_ValidInput.json");
            yield return new TestCaseData(languageModel).SetCategory("language");
        }

        public static IEnumerable<TestCaseData> UpdateLanguageValidData()
        {
            var languageModel = JsonHelper.ReadJson<LanguageModel>("TestData/UpdateLanguages_ValidInput.json");
            yield return new TestCaseData(languageModel).SetCategory("language");
        }

        public static IEnumerable<TestCaseData> DeleteLanguageValidData()
        {
            var languageModel = JsonHelper.ReadJson<LanguageModel>("TestData/DeleteLanguages_ValidInput.json");
            yield return new TestCaseData(languageModel).SetCategory("language");
        }

        public static IEnumerable<TestCaseData> UpdateLanguageWithExistingData()
        {
            var languageModel = JsonHelper.ReadJson<LanguageModel>("TestData/UpdateLanguageWithExistingInput_ValidNegativeTest.json");
            yield return new TestCaseData(languageModel).SetCategory("language");
        }

        public static IEnumerable<TestCaseData> AddLanguagesInvalidData()
        {
            var languageModel = JsonHelper.ReadJson<LanguageModel>("TestData/AddLanguages_InvalidInput.json");
            yield return new TestCaseData(languageModel).SetCategory("language");
        }

        public static IEnumerable<TestCaseData> UpdateLanguagesInvalidData()
        {
            var languageModel = JsonHelper.ReadJson<LanguageModel>("TestData/UpdateLanguages_InvalidInput.json");
            yield return new TestCaseData(languageModel).SetCategory("language");
        }
        public static IEnumerable<TestCaseData> AddLanguageDataWhenSessionExpired()
        {
            var languageModel = JsonHelper.ReadJson<LanguageModel>("TestData/AddLanguage_SessionExpired.json");
            yield return new TestCaseData(languageModel).SetCategory("language");
        }

        public static IEnumerable<TestCaseData> UpdateLanguageDataWhenSessionExpired()
        {
            var languageModel = JsonHelper.ReadJson<LanguageModel>("TestData/UpdateLanguage_SessionExpired.json");
            yield return new TestCaseData(languageModel).SetCategory("language");
        }

        public static IEnumerable<TestCaseData> DeleteLanguageDataWhenSessionExpired()
        {
            var languageModel = JsonHelper.ReadJson<LanguageModel>("TestData/DeleteLanguage_SessionExpired.json");
            yield return new TestCaseData(languageModel).SetCategory("language");
        }

        public static IEnumerable<TestCaseData> CancelAddLanguageData()
        {
            var languageModel = JsonHelper.ReadJson<LanguageModel>("TestData/AddLanguage_Cancel.json");
            yield return new TestCaseData(languageModel).SetCategory("language");
        }

        public static IEnumerable<TestCaseData> CancelUpdateLanguageData()
        {
            var languageModel = JsonHelper.ReadJson<LanguageModel>("TestData/UpdateLanguage_Cancel.json");
            yield return new TestCaseData(languageModel).SetCategory("language");
        }

        public static IEnumerable<TestCaseData> LeaveEitherOneOrAllTheFieldsAreEmptyForAddLanguage()
        {
            var languageModel = JsonHelper.ReadJson<LanguageModel>("TestData/AddLanguage_LeaveEitherOneOrAllTheFieldsEmpty.json");
            yield return new TestCaseData(languageModel).SetCategory("language");
        }

        public static IEnumerable<TestCaseData> LeaveEitherOneOrAllTheFieldsAreEmptyForUpdateLanguage()
        {
            var languageModel = JsonHelper.ReadJson<LanguageModel>("TestData/UpdateLanguage_LeaveEitherOneOrAllTheFieldsEmpty.json");
            yield return new TestCaseData(languageModel).SetCategory("language");
        }

        public static IEnumerable<TestCaseData> AddHugeLanguageDestructiveTestData()
        {
            var languageModel = JsonHelper.ReadJson<LanguageModel>("TestData/AddHugeLanguage_DestructiveTestData.json");
            yield return new TestCaseData(languageModel).SetCategory("language");
        }

        public static IEnumerable<TestCaseData> UpdateHugeLanguageDestructiveTestData()
        {
            var languageModel = JsonHelper.ReadJson<LanguageModel>("TestData/UpdateHugeData_DestructiveTestData.json");
            yield return new TestCaseData(languageModel).SetCategory("language");
        }

        public static IEnumerable<TestCaseData> AddLanguageWithExistingLanguageTestData()
        {
            var languageModel = JsonHelper.ReadJson<LanguageModel>("TestData/AddLanguage_ExistingLanguageTestData.json");
            yield return new TestCaseData(languageModel).SetCategory("language");
        }

        public static IEnumerable<TestCaseData> AddLanguageWithExistingLanguageAndLevelTestData()
        {
            var languageModel = JsonHelper.ReadJson<LanguageModel>("TestData/AddLanguage_ExistingLanguageAndLevelTestData.json");
            yield return new TestCaseData(languageModel).SetCategory("language");
        }

        //Skills data provider methods

        public static IEnumerable<TestCaseData> AddSkillsValidData()
        {
            var skillsModel = JsonHelper.ReadJson<SkillsModel>("TestData/AddSkills_ValidInput.json");
            yield return new TestCaseData(skillsModel).SetCategory("skills");
        }

        public static IEnumerable<TestCaseData> UpdateSkillsValidData()
        {
            var skillsModel = JsonHelper.ReadJson<SkillsModel>("TestData/UpdateSkills_ValidInput.json");
            yield return new TestCaseData(skillsModel).SetCategory("skills");
        }

        public static IEnumerable<TestCaseData> DeleteSkillsValidData()
        {
            var skillsModel = JsonHelper.ReadJson<SkillsModel>("TestData/DeleteSkills_ValidInput.json");
            yield return new TestCaseData(skillsModel).SetCategory("skills");
        }

        public static IEnumerable<TestCaseData> UpdateSkillsWithExistingSkillDifferentLevelData()
        {
            var skillsModel = JsonHelper.ReadJson<SkillsModel>("TestData/UpdateSkills_ExistingSkillDifferentLevel.json");
            yield return new TestCaseData(skillsModel).SetCategory("skills");
        }

        public static IEnumerable<TestCaseData> AddSkillsWhenSessionExpired()
        {
            var skillsModel = JsonHelper.ReadJson<SkillsModel>("TestData/AddSkills_WhenSessionExpired.json");
            yield return new TestCaseData(skillsModel).SetCategory("skills");
        }

        public static IEnumerable<TestCaseData> UpdateSkillsWhenSessionExpired()
        {
            var skillsModel = JsonHelper.ReadJson<SkillsModel>("TestData/UpdateSkills_WhenSessionExpired.json");
            yield return new TestCaseData(skillsModel).SetCategory("skills");
        }

        public static IEnumerable<TestCaseData> DeleteSkillsWhenSessionExpired()
        {
            var skillsModel = JsonHelper.ReadJson<SkillsModel>("TestData/DeleteSkills_WhenSessionExpired.json");
            yield return new TestCaseData(skillsModel).SetCategory("skills");
        }

        public static IEnumerable<TestCaseData> CancelAddSkills()
        {
            var skillsModel = JsonHelper.ReadJson<SkillsModel>("TestData/AddSkills_Cancel.json");
            yield return new TestCaseData(skillsModel).SetCategory("skills");
        }

        public static IEnumerable<TestCaseData> CancelUpdateSkills()
        {
            var skillsModel = JsonHelper.ReadJson<SkillsModel>("TestData/UpdateSkills_Cancel.json");
            yield return new TestCaseData(skillsModel).SetCategory("skills");
        }

        public static IEnumerable<TestCaseData> LeaveEitherOneOrAllTheFieldsEmptyToAddSkills()
        {
            var skillsModel = JsonHelper.ReadJson<SkillsModel>("TestData/AddSkills_LeaveEitherOneOrAllTheFieldsEmpty.json");
            yield return new TestCaseData(skillsModel).SetCategory("skills");
        }

        public static IEnumerable<TestCaseData> LeaveEitherOneOrAllTheFieldsAreEmptyToUpdateSkills()
        {
            var skillsModel = JsonHelper.ReadJson<SkillsModel>("TestData/UpdateSkills_LeaveEitherOneOrAllTheFieldsEmpty.json");
            yield return new TestCaseData(skillsModel).SetCategory("skills");
        }

        public static IEnumerable<TestCaseData> AddSkillsInvalidData()
        {
            var skillModel = JsonHelper.ReadJson<SkillsModel>("TestData/AddSkills_InvalidInput.json");
            yield return new TestCaseData(skillModel).SetCategory("skills");
        }

        public static IEnumerable<TestCaseData> UpdateSkillsInvalidData()
        {
            var skillModel = JsonHelper.ReadJson<SkillsModel>("TestData/UpdateSkills_InvalidInput.json");
            yield return new TestCaseData(skillModel).SetCategory("skills");
        }

        public static IEnumerable<TestCaseData> AddSkillLengthyStringTestData()
        {
            var skillsModel = JsonHelper.ReadJson<SkillsModel>("TestData/AddSkill_LengthyString.json");
            yield return new TestCaseData(skillsModel).SetCategory("skills");
        }

        public static IEnumerable<TestCaseData> AddHugeSkillDestructiveTestData()
        {
            var skillsModel = JsonHelper.ReadJson<SkillsModel>("TestData/AddSkills_DestructiveTest.json");
            yield return new TestCaseData(skillsModel).SetCategory("skills");
        }

        public static IEnumerable<TestCaseData> UpdateHugeSkillDestructiveTestData()
        {
            var skillsModel = JsonHelper.ReadJson<SkillsModel>("TestData/UpdateSkills_DestructiveTestData.json");
            yield return new TestCaseData(skillsModel).SetCategory("skills");
        }

        public static IEnumerable<TestCaseData> AddSkillsWithExistingSkillAndLevel()
        {
            var skillsModel = JsonHelper.ReadJson<SkillsModel>("TestData/AddSkills_ExistingSkillAndLevel.json");
            yield return new TestCaseData(skillsModel).SetCategory("skills");
        }

        public static IEnumerable<TestCaseData> AddSkillWithExistingSkillAndDifferentLevel()
        {
            var skillsModel = JsonHelper.ReadJson<SkillsModel>("TestData/AddSkill_ExistingSkillAndDifferentLevel.json");
            yield return new TestCaseData(skillsModel).SetCategory("skills");
        }

        //Education data provider methods
        public static IEnumerable<TestCaseData> AddEducationDetailsValidData()
        {
            var educationModel = JsonHelper.ReadJson<EducationModel>("TestData/AddEducationDetails_ValidInput.json");
            yield return new TestCaseData(educationModel).SetCategory("education");
        }

        public static IEnumerable<TestCaseData> AddEducationDetailsInvalidCollegeUniversityData()
        {
            var educationModel = JsonHelper.ReadJson<EducationModel>("TestData/AddEducationDetails_InvalidCollegeUniversityName.json");
            yield return new TestCaseData(educationModel).SetCategory("education");
        }

        public static IEnumerable<TestCaseData> AddEducationDetailsInvalidDegreeData()
        {
            var educationModel = JsonHelper.ReadJson<EducationModel>("TestData/AddEducationDetails_InvalidDegree.json");
            yield return new TestCaseData(educationModel).SetCategory("education");
        }

        public static IEnumerable<TestCaseData> AddEducationDetailsNegativeTestingValidData()
        {
            var educationModel = JsonHelper.ReadJson<EducationModel>("TestData/AddEducationDetails_NegativeTestingWithValidInput.json");
            yield return new TestCaseData(educationModel).SetCategory("education");
        }

        public static IEnumerable<TestCaseData> AddEducationDetailsLeaveEitherOneOrAllTheFieldsEmpty()
        {
            var educationModel = JsonHelper.ReadJson<EducationModel>("TestData/AddEducationDetails_LeaveEitherOneOrAllTheFieldsEmpty.json");
            yield return new TestCaseData(educationModel).SetCategory("education");
        }

        public static IEnumerable<TestCaseData> AddEducationDetailsMoreThan250CharactersOfCollegeUniversityName()
        {
            var educationModel = JsonHelper.ReadJson<EducationModel>("TestData/AddEducationDetails_MoreThan250CharactersOfCollegeUniversityName.json");
            yield return new TestCaseData(educationModel).SetCategory("education");
        }

        public static IEnumerable<TestCaseData> AddEducationDetailsMoreThan250CharactersOfDegreeName()
        {
            var educationModel = JsonHelper.ReadJson<EducationModel>("TestData/AddEducationDetails_MoreThan250CharactersOfDegreeName.json");
            yield return new TestCaseData(educationModel).SetCategory("education");
        }

        public static IEnumerable<TestCaseData> AddEducationDetailsWhenSessionExpired()
        {
            var educationModel = JsonHelper.ReadJson<EducationModel>("TestData/AddEducationDetails_WhenSessionExpired.json");
            yield return new TestCaseData(educationModel).SetCategory("education");
        }

        public static IEnumerable<TestCaseData> AddEducationDetailsDuplicateData()
        {
            var educationModel = JsonHelper.ReadJson<EducationModel>("TestData/AddEducationDetails_DuplicateData.json");
            yield return new TestCaseData(educationModel).SetCategory("education");
        }

        public static IEnumerable<TestCaseData> AddEducationDetailsCancel()
        {
            var educationModel = JsonHelper.ReadJson<EducationModel>("TestData/AddEducationDetails_Cancel.json");
            yield return new TestCaseData(educationModel).SetCategory("education");
        }

        public static IEnumerable<TestCaseData> AddEducationDetailsDestructiveTestData()
        {
            var educationModel = JsonHelper.ReadJson<EducationModel>("TestData/AddEducationDetails_DestructiveTesting.json");
            yield return new TestCaseData(educationModel).SetCategory("education");
        }

        public static IEnumerable<TestCaseData> UpdateEducationDetailsWithValidData()
        {
            var educationModel = JsonHelper.ReadJson<EducationModel>("TestData/UpdateEducationDetails_ValidInput.json");
            yield return new TestCaseData(educationModel).SetCategory("education");
        }

        public static IEnumerable<TestCaseData> UpdateEducationDetailsWhenSessionExpired()
        {
            var educationModel = JsonHelper.ReadJson<EducationModel>("TestData/UpdateEducationDetails_WhenSessionExpired.json");
            yield return new TestCaseData(educationModel).SetCategory("education");
        }

        public static IEnumerable<TestCaseData> UpdateEducationDetailsWithValidInputNegativeTesting()
        {
            var educationModel = JsonHelper.ReadJson<EducationModel>("TestData/UpdateEducationDetails_NegativeTestingWithValidInput.json");
            yield return new TestCaseData(educationModel).SetCategory("education");
        }

        public static IEnumerable<TestCaseData> UpdateEducationDetailsWithInvalidCollegeName()
        {
            var educationModel = JsonHelper.ReadJson<EducationModel>("TestData/UpdateEducationDetails_InvalidCollegeUniversityName.json");
            yield return new TestCaseData(educationModel).SetCategory("education");
        }

        public static IEnumerable<TestCaseData> UpdateEducationDetailsWithInvalidDegreeName()
        {
            var educationModel = JsonHelper.ReadJson<EducationModel>("TestData/UpdateEducationDetails_InvalidDegreeName.json");
            yield return new TestCaseData(educationModel).SetCategory("education");
        }

        public static IEnumerable<TestCaseData> UpdateEducationDetailsLeaveEitherOneOrAllTheFieldsEmpty()
        {
            var educationModel = JsonHelper.ReadJson<EducationModel>("TestData/UpdateEducationDetails_LeaveEitherOneOrAllTheFieldsEmpty.json");
            yield return new TestCaseData(educationModel).SetCategory("education");
        }

        public static IEnumerable<TestCaseData> UpdateEducationDetailsWithExistingData()
        {
            var educationModel = JsonHelper.ReadJson<EducationModel>("TestData/UpdateEducationDetails_DuplicateData.json");
            yield return new TestCaseData(educationModel).SetCategory("education");
        }

        public static IEnumerable<TestCaseData> UpdateEducationDetailsMoreThan250CharactersOfCollegeUniversityName()
        {
            var educationModel = JsonHelper.ReadJson<EducationModel>("TestData/UpdateEducationDetails_MoreThan250CharactersOfCollegeUniversityName.json");
            yield return new TestCaseData(educationModel).SetCategory("education");
        }

        public static IEnumerable<TestCaseData> UpdateEducationDetailsMoreThan250CharactersOfDegreeName()
        {
            var educationModel = JsonHelper.ReadJson<EducationModel>("TestData/UpdateEducationDetails_MoreThan250CharactersOfDegreeName.json");
            yield return new TestCaseData(educationModel).SetCategory("education");
        }

        public static IEnumerable<TestCaseData> UpdateEducationDetailsDestructiveTestData()
        {
            var educationModel = JsonHelper.ReadJson<EducationModel>("TestData/UpdateEducationDetails_DestructiveTesting.json");
            yield return new TestCaseData(educationModel).SetCategory("education");
        }

        public static IEnumerable<TestCaseData> DeleteEducationDetails()
        {
            var educationModel = JsonHelper.ReadJson<EducationModel>("TestData/DeleteEducationDetails_ValidInput.json");
            yield return new TestCaseData(educationModel).SetCategory("education");
        }

        public static IEnumerable<TestCaseData> DeleteEducationDetailsWhenSessionExpired()
        {
            var educationModel = JsonHelper.ReadJson<EducationModel>("TestData/DeleteEducationDetails_WhenSessionExpired.json");
            yield return new TestCaseData(educationModel).SetCategory("education");
        }

        //Certification data provider methods
        public static IEnumerable<TestCaseData> AddCertificationDetailsValidData()
        {
            var certificationModel = JsonHelper.ReadJson<CertificationModel>("TestData/AddCertificationDetails_ValidInput.json");
            yield return new TestCaseData(certificationModel).SetCategory("certification");
        }

        public static IEnumerable<TestCaseData> AddCertificationDetailsInvalidCertificateOrAwardData()
        {
            var certificationModel = JsonHelper.ReadJson<CertificationModel>("TestData/AddCertificationDetails_InvalidCertificateOrAward.json");
            yield return new TestCaseData(certificationModel).SetCategory("certification");
        }

        public static IEnumerable<TestCaseData> AddCertificationDetailsInvalidCertificateFromData()
        {
            var certificationModel = JsonHelper.ReadJson<CertificationModel>("TestData/AddCertificationDetails_InvalidCertificateFrom.json");
            yield return new TestCaseData(certificationModel).SetCategory("certification");
        }

        public static IEnumerable<TestCaseData> AddCertificationDetailsCertificateOrAwardAndCertificateMismatchData()
        {
            var certificationModel = JsonHelper.ReadJson<CertificationModel>("TestData/AddCertificationDetails_CertificateOrAwardAndCertificateMismatch.json");
            yield return new TestCaseData(certificationModel).SetCategory("certification");
        }

        public static IEnumerable<TestCaseData> AddCertificationDetailsLeaveEitherOneOrAllTheFieldsEmptyData()
        {
            var certificationModel = JsonHelper.ReadJson<CertificationModel>("TestData/AddCertificationDetails_LeaveEitherOneOrAllTheFieldsEmpty.json");
            yield return new TestCaseData(certificationModel).SetCategory("certification");
        }

        public static IEnumerable<TestCaseData> AddCertificationDetailsMoreThan250CharactersOfCertificateFromData()
        {
            var certificationModel = JsonHelper.ReadJson<CertificationModel>("TestData/AddCertificationDetails_MoreThan250CharactersOfCertificateFrom.json");
            yield return new TestCaseData(certificationModel).SetCategory("certification");
        }

        public static IEnumerable<TestCaseData> AddCertificationDetailsMoreThan250CharactersOfCertificateOrAwardData()
        {
            var certificationModel = JsonHelper.ReadJson<CertificationModel>("TestData/AddCertificationDetails_MoreThan250CharactersOfCertificateOrAward.json");
            yield return new TestCaseData(certificationModel).SetCategory("certification");
        }

        public static IEnumerable<TestCaseData> AddCertificationDetailsDuplicateData()
        {
            var certificationModel = JsonHelper.ReadJson<CertificationModel>("TestData/AddCertificationDetails_DuplicateData.json");
            yield return new TestCaseData(certificationModel).SetCategory("certification");
        }

        public static IEnumerable<TestCaseData> AddCertificationDetailsDestructiveTestingData()
        {
            var certificationModel = JsonHelper.ReadJson<CertificationModel>("TestData/AddCertificationDetails_DestructiveTesting.json");
            yield return new TestCaseData(certificationModel).SetCategory("certification");
        }

        public static IEnumerable<TestCaseData> AddCertificationDetailsCancel()
        {
            var certificationModel = JsonHelper.ReadJson<CertificationModel>("TestData/AddCertificationDetails_Cancel.json");
            yield return new TestCaseData(certificationModel).SetCategory("certification");
        }

        public static IEnumerable<TestCaseData> AddCertificationDetailsWhenSessionExpired()
        {
            var certificationModel = JsonHelper.ReadJson<CertificationModel>("TestData/AddCertificationDetails_WhenSessionExpired.json");
            yield return new TestCaseData(certificationModel).SetCategory("certification");
        }

        public static IEnumerable<TestCaseData> UpdateCertificationDetailsValidData()
        {
            var certificationModel = JsonHelper.ReadJson<CertificationModel>("TestData/UpdateCertificationDetails_ValidInput.json");
            yield return new TestCaseData(certificationModel).SetCategory("certification");
        }

        public static IEnumerable<TestCaseData> UpdateCertificationDetailsInvalidCertificateOrAwardData()
        {
            var certificationModel = JsonHelper.ReadJson<CertificationModel>("TestData/UpdateCertificationDetails_InvalidCertificateOrAward.json");
            yield return new TestCaseData(certificationModel).SetCategory("certification");
        }

        public static IEnumerable<TestCaseData> UpdateCertificationDetailsInvalidCertificateFromData()
        {
            var certificationModel = JsonHelper.ReadJson<CertificationModel>("TestData/UpdateCertificationDetails_InvalidCertificateFrom.json");
            yield return new TestCaseData(certificationModel).SetCategory("certification");
        }

        public static IEnumerable<TestCaseData> UpdateCertificationDetailsLeaveEitherOneOrAllTheFieldsEmptyData()
        {
            var certificationModel = JsonHelper.ReadJson<CertificationModel>("TestData/UpdateCertificationDetails_LeaveEitherOneOrAllTheFieldsEmpty.json");
            yield return new TestCaseData(certificationModel).SetCategory("certification");
        }

        public static IEnumerable<TestCaseData> UpdateCertificationDetailsCertificateOrAwardAndCertifiedFromMismatch()
        {
            var certificationModel = JsonHelper.ReadJson<CertificationModel>("TestData/UpdateCertificationDetails_CertificateOrAwardAndCertificateFromMismatch.json");
            yield return new TestCaseData(certificationModel).SetCategory("certification");
        }

        public static IEnumerable<TestCaseData> UpdateCertificationDetailsDuplicateData()
        {
            var certificationModel = JsonHelper.ReadJson<CertificationModel>("TestData/UpdateCertificationDetails_DuplicateData.json");
            yield return new TestCaseData(certificationModel).SetCategory("certification");
        }

        public static IEnumerable<TestCaseData> UpdateCertificationDetailsCancel()
        {
            var certificationModel = JsonHelper.ReadJson<CertificationModel>("TestData/UpdateCertificationDetails_Cancel.json");
            yield return new TestCaseData(certificationModel).SetCategory("certification");
        }

        public static IEnumerable<TestCaseData> UpdateCertificationDetailsMoreThan250CharactersOfCertificateOrAward()
        {
            var certificationModel = JsonHelper.ReadJson<CertificationModel>("TestData/UpdateCertificationDetails_MoreThan250CharactersOfCertificateOrAward.json");
            yield return new TestCaseData(certificationModel).SetCategory("certification");
        }

        public static IEnumerable<TestCaseData> UpdateCertificationDetailsMoreThan250CharactersOfCertificateFrom()
        {
            var certificationModel = JsonHelper.ReadJson<CertificationModel>("TestData/UpdateCertificationDetails_MoreThan250CharactersOfCertificateFrom.json");
            yield return new TestCaseData(certificationModel).SetCategory("certification");
        }

        public static IEnumerable<TestCaseData> UpdateCertificationDetailsWhenSessionExpired()
        {
            var certificationModel = JsonHelper.ReadJson<CertificationModel>("TestData/UpdateCertificationDetails_WhenSessionExpired.json");
            yield return new TestCaseData(certificationModel).SetCategory("certification");
        }

        public static IEnumerable<TestCaseData> UpdateCertificationDetailsDestructiveTesting()
        {
            var certificationModel = JsonHelper.ReadJson<CertificationModel>("TestData/UpdateCertificationDetails_DestructiveTesting.json");
            yield return new TestCaseData(certificationModel).SetCategory("certification");
        }

        public static IEnumerable<TestCaseData> DeleteCertificationDetails()
        {
            var certificationModel = JsonHelper.ReadJson<CertificationModel>("TestData/DeleteCertificationDetails_ValidInput.json");
            yield return new TestCaseData(certificationModel).SetCategory("certification");
        }

        public static IEnumerable<TestCaseData> DeleteCertificationDetailsWhenSessionExpired()
        {
            var certificationModel = JsonHelper.ReadJson<CertificationModel>("TestData/DeleteCertificationDetails_WhenSessionExpired.json");
            yield return new TestCaseData(certificationModel).SetCategory("certification");
        }

        //Profile about me data provider methods
        public static IEnumerable<TestCaseData> ProfileOverviewValidEntireFlow()
        {
            var profileOverviewModel = JsonHelper.ReadJson<ProfileOverviewModel>("TestData/ProfileOverview_ValidEnireFlow.json");
            yield return new TestCaseData(profileOverviewModel).SetCategory("profileOverview");
        }

        public static IEnumerable<TestCaseData> ProfileOverviewValidUserName()
        {
            var profileOverviewModel = JsonHelper.ReadJson<ProfileOverviewModel>("TestData/ProfileOverview_ValidUserName.json");
            yield return new TestCaseData(profileOverviewModel).SetCategory("profileOverview");
        }

        public static IEnumerable<TestCaseData> ProfileOverviewInvalidUserName()
        {
            var profileOverviewModel = JsonHelper.ReadJson<ProfileOverviewModel>("TestData/ProfileOverview_InvalidUserName.json");
            yield return new TestCaseData(profileOverviewModel).SetCategory("profileOverview");
        }

        public static IEnumerable<TestCaseData> ProfileOverviewLeaveEitherOneOrAllTheFieldsEmpty()
        {
            var profileOverviewModel = JsonHelper.ReadJson<ProfileOverviewModel>("TestData/ProfileOverview_LeaveEitherOneOrBothTheFieldsAreEmpty.json");
            yield return new TestCaseData(profileOverviewModel).SetCategory("profileOverview");
        }

        public static IEnumerable<TestCaseData> ProfileOverviewAddValidUserNameWhenSessionExpired()
        {
            var profileOverviewModel = JsonHelper.ReadJson<ProfileOverviewModel>("TestData/ProfileOverview_AddValidUserNameWhenSessionExpired.json");
            yield return new TestCaseData(profileOverviewModel).SetCategory("profileOverview");
        }

        public static IEnumerable<TestCaseData> ProfileOverviewUpdateAvailability()
        {
            var profileOverviewModel = JsonHelper.ReadJson<ProfileOverviewModel>("TestData/ProfileOverview_UpdateAvailability.json");
            yield return new TestCaseData(profileOverviewModel).SetCategory("profileOverview");
        }

        public static IEnumerable<TestCaseData> ProfileOverviewCancelAvailabilityUpdate()
        {
            var profileOverviewModel = JsonHelper.ReadJson<ProfileOverviewModel>("TestData/ProfileOverview_CancelAvailabilityUpdate.json");
            yield return new TestCaseData(profileOverviewModel).SetCategory("profileOverview");
        }

        public static IEnumerable<TestCaseData> ProfileOverviewAvailabilityUpdateWhenSessionExpired()
        {
            var profileOverviewModel = JsonHelper.ReadJson<ProfileOverviewModel>("TestData/ProfileOverview_UpdateAvailabilityWhenSessionExpired.json");
            yield return new TestCaseData(profileOverviewModel).SetCategory("profileOverview");
        }

        public static IEnumerable<TestCaseData> ProfileOverviewUpdateHours()
        {
            var profileOverviewModel = JsonHelper.ReadJson<ProfileOverviewModel>("TestData/ProfileOverview_UpdateHours.json");
            yield return new TestCaseData(profileOverviewModel).SetCategory("profileOverview");
        }

        public static IEnumerable<TestCaseData> ProfileOverviewCancelHoursUpdate()
        {
            var profileOverviewModel = JsonHelper.ReadJson<ProfileOverviewModel>("TestData/ProfileOverview_CancelHoursUpdate.json");
            yield return new TestCaseData(profileOverviewModel).SetCategory("profileOverview");
        }

        public static IEnumerable<TestCaseData> ProfileOverviewUpdateHoursWhenSessionExpired()
        {
            var profileOverviewModel = JsonHelper.ReadJson<ProfileOverviewModel>("TestData/ProfileOverview_UpdateHoursWhenSessionExpired.json");
            yield return new TestCaseData(profileOverviewModel).SetCategory("profileOverview");
        }

        public static IEnumerable<TestCaseData> ProfileOverviewUpdateEarnTarget()
        {
            var profileOverviewModel = JsonHelper.ReadJson<ProfileOverviewModel>("TestData/ProfileOverview_UpdateEarnTarget.json");
            yield return new TestCaseData(profileOverviewModel).SetCategory("profileOverview");
        }

        public static IEnumerable<TestCaseData> ProfileOverviewCancelEarnTargetUpdate()
        {
            var profileOverviewModel = JsonHelper.ReadJson<ProfileOverviewModel>("TestData/ProfileOverview_CancelEarnTargetUpdate.json");
            yield return new TestCaseData(profileOverviewModel).SetCategory("profileOverview");
        }

        public static IEnumerable<TestCaseData> ProfileOverviewUpdateEarnTargetWhenSessionExpired()
        {
            var profileOverviewModel = JsonHelper.ReadJson<ProfileOverviewModel>("TestData/ProfileOverview_UpdateEarnTargetWhenSessionExpired.json");
            yield return new TestCaseData(profileOverviewModel).SetCategory("profileOverview");
        }

        public static IEnumerable<TestCaseData> ShareSkill_ValidInput()
        {
            var shareSkillModel = JsonHelper.ReadJson<ShareSkillModel>("TestData/ShareSkill_ValidInput.json");
            yield return new TestCaseData(shareSkillModel).SetCategory("shareSkill");
        }
    }
}

