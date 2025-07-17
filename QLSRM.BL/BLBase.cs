using QLSRM.DL;
using QLSRM.Library;
using QLSRM.Models;

namespace QLSRM.BL
{
    public class BLBase
    {
        public DLBase _dlBase { get; set; }
        public BLBase()
        {
            _dlBase = new DLBase();
        }
        public virtual void PreSaveData<T>(List<T> datas)
        {

        }
        public virtual void AfterSaveData<T>(List<T> datas)
        {

        }
        public virtual void AfterSaveDataSuccess<T>(List<T> datas)
        {

        }
        public virtual bool ValidateData<T>(List<T> datas, ref Response res)
        {
            res = res != null ? res : new Response();
            return true;
        }
        public bool SaveData<T>(List<T> datas,  Response res = null )
        {
            var success = false;
            res = res != null ? res : new Response();
            if (ValidateData(datas, ref res))
            {
                PreSaveData(datas);
                success = _dlBase.SaveData(datas);
                AfterSaveData(datas);
                if (success)
                {
                    AfterSaveDataSuccess(datas);
                }
            }
            return success;
        }
        public List<T> SelectAll<T>()
        {
            return _dlBase.SelectAll<T>(new { Role = Session.Role, UserId = Session.UserId });
        }
        public T SelectNewCode<T>(string tableName)
        {
            return _dlBase.SelectNewCode<T>(tableName);
        }
        public T GetById<T>(long id)
        {
            return _dlBase.GetById<T>(id);
        }
        public T SelectEmployeeByEmail<T>(string email)
        {
            return _dlBase.SelectEmployeeByEmail<T>(email);
        }
    }
}