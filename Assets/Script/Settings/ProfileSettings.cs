using UnityEngine;

[CreateAssetMenu(menuName = "Game assets/ProfileSettings", fileName = "ProfileSettings")]
public class ProfileSettings : ScriptableObject
{
    [Tooltip("Иконка")] [SerializeField] private Sprite _icon;
    [SerializeField] private Sprite _iconAfterDopros;
    [Tooltip("Позывной")] [SerializeField] private string _nickname;
    [Tooltip("Возраст")] [SerializeField] private int _age;
    [Tooltip("Семейное положение")] [SerializeField] private string _familyStatus;
    [Tooltip("Уровень допуска")] [SerializeField] private string _accessLevel;
    [Tooltip("Должность")] [SerializeField] private string _jobPosition;
    [Tooltip("Род деятельности")] [SerializeField][TextAreaAttribute] private string _occupation;

    public Sprite Icon => _icon;
    public Sprite IconAfteDopros => _iconAfterDopros;
    public string Nickname => _nickname.NicknameString();
    public int Age => _age;
    public string AgeString => _age.AgeString();
    public string FamilyStatus => _familyStatus.FamilyStatusString();
    public string AccessLevel => _accessLevel.AccessLevelString();
    public string JobPosition => _jobPosition.JobPositionString();
    public string Occupation => _occupation.OccupationString();
}
