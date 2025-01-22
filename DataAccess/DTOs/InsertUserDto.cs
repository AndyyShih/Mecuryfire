namespace DataAccess.DTOs
{
    public class InsertUserDto
    {
        /// <summary>
        /// 中文名稱
        /// </summary>
        public string? CName { get; set; }

        /// <summary>
        /// 英文名稱
        /// </summary>
        public string? EName { get; set; }

        /// <summary>
        /// 簡稱
        /// </summary>
        public string? SName { get; set; }

        /// <summary>
        /// 電子郵件
        /// </summary>
        public string? Email { get; set; }

        /// <summary>
        /// 狀態（預設為 0）
        /// </summary>
        public byte Status { get; set; } = 0;

        /// <summary>
        /// 是否停用（預設為 false）
        /// </summary>
        public bool Stop { get; set; } = false;

        /// <summary>
        /// 停用備註
        /// </summary>
        public string? StopMemo { get; set; }

        /// <summary>
        /// 登入帳號
        /// </summary>
        public string? LoginID { get; set; }

        /// <summary>
        /// 登入密碼
        /// </summary>
        public string? LoginPWD { get; set; }

        /// <summary>
        /// 備註
        /// </summary>
        public string? Memo { get; set; }

        /// <summary>
        /// 建立人員 ID
        /// </summary>
        public string? NowID { get; set; }
    }
}
