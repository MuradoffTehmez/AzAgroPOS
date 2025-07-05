using AzAgroPOS.DAL;
using AzAgroPOS.Entities;
using System;
using System.Collections.Generic;

namespace AzAgroPOS.BLL
{
    /// <summary>
    /// Əməliyyat jurnalı ilə bağlı biznes məntiqi əməliyyatlarını həyata keçirir.
    /// </summary>
    public class EmeliyyatJurnaliBLL
    {
        private readonly EmeliyyatJurnaliDAL _dal = new EmeliyyatJurnaliDAL();

        /// <summary>
        /// Əməliyyat jurnalında axtarış edir.
        /// </summary>
        /// <param name="startDate">Başlanğıc tarixi</param>
        /// <param name="endDate">Bitmə tarixi</param>
        /// <param name="userId">İstifadəçi ID-si (null olarsa, bütün istifadəçilər üçün axtarış edir)</param>
        /// <param name="keyword">Açar söz (əməliyyat növü və ya təsvirdə axtarış üçün)</param>
        /// <returns>Əməliyyat jurnalı siyahısı</returns>
        public List<EmeliyyatJurnali> Search(DateTime startDate, DateTime endDate, int? userId = null, string keyword = null)
        {
            try
            {
                return _dal.Search(startDate, endDate, userId, keyword);
            }
            catch (Exception ex)
            {
                // Xətanı loglamaq və ya istifadəçiyə bildirmək üçün əlavə edilə bilər
                throw new Exception("Əməliyyat jurnalında axtarış edilərkən xəta baş verdi.", ex);
            }
        }

        /// <summary>
        /// Əməliyyat jurnalına yeni qeyd əlavə edir.
        /// </summary>
        /// <param name="istifadeciId">İstifadəçi ID-si</param>
        /// <param name="emeliyyatNovu">Əməliyyat növü</param>
        /// <param name="tesvir">Əməliyyat təsviri</param>
        public void LogEmeliyyat(int istifadeciId, string emeliyyatNovu, string tesvir)
        {
            try
            {
                var log = new EmeliyyatJurnali
                {
                    IstifadeciId = istifadeciId,
                    EmeliyyatNovu = emeliyyatNovu,
                    Tesvir = tesvir
                };

                _dal.Add(log);
            }
            catch (Exception ex)
            {
                throw new Exception("Əməliyyat jurnalına qeyd əlavə edilərkən xəta baş verdi.", ex);
            }
        }
    }
}