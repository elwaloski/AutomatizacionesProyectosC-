using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carga_Directa_BD_SE
{
    class Definiciones
    {
        public String Dte_rang_foli_hold(String Holding,String Rut, String digi)
        {
                       
            String CAF33 = "INSERT[dbo].[dte_rang_foli_hold]([codi_emex], [codi_empr], [tipo_dora], [foli_desd], [foli_hast], [fech_soli], [fech_auto], [codi_ceco], [esta_rafo], [llav_priv_rafo], [llav_publ_rafo], [ulti_foli], [rutt_empr], [digi_empr], [llav_puco_modu], [llav_puco_expo], [llav_pusi_iden], [codi_ofic], [codi_pers], [firm_sii], [arch_caf], [razo_soci], [ulti_asig], [caf_ingr], [fech_venc]) VALUES('"+ Holding + "', 1, 33 , 1 ,2000000, NULL, CAST(N'2022-10-11 00:00:00.000' AS DateTime), NULL, 'VAL','-----BEGIN RSA PRIVATE KEY-----" +
                      "MIIBOQIBAAJBALErOEQuYRSuk/rIkAkkBO2S5tTQXg6rZef0JYj2TfeTwiEOeX0s" +
                      "uGo2RYhc/bbFC89eQnQvB76vfoETxl8+f08CAQMCQHYc0C10QLh0YqcwYAYYA0kM" +
                      "meM1lAnHmUVNbltO3qUMD7ySIw4vC5yxdsqkspJbb1RoDWXONe1/U6AMorwSe3sC" +
                      "IQDgdxL3QB+FC8Em2p29lVkCJYM/4K+6scI8sDII2mTwawIhAMoPIE2nxqHzaux9" +
                      "yDRF4uKrPu56yfworkRgzslqvdWtAiEAlaS3T4AVA10rbzxpKQ47VsOs1UB1JyEs" +
                      "KHV2sJGYoEcCIQCGtMAzxS8WokdIU9rNg+yXHNSe/IaoGx7YQInbnH6OcwIgf6nF" +
                      "SL7G4bVtvootVG6KNKioQVXr/0xBnflBd2ulvbQ=" +
                      "-----END RSA PRIVATE KEY-----" +
                      "', N'-----BEGIN PUBLIC KEY-----" +
                      "MFowDQYJKoZIhvcNAQEBBQADSQAwRgJBALErOEQuYRSuk/rIkAkkBO2S5tTQXg6r" +
                      "Zef0JYj2TfeTwiEOeX0suGo2RYhc/bbFC89eQnQvB76vfoETxl8+f08CAQM=" +
                      "-----END PUBLIC KEY-----" +
                      "', NULL,"+ Rut + ", '"+digi+"', N'sSs4RC5hFK6T+siQCSQE7ZLm1NBeDqtl5/QliPZN95PCIQ55fSy4ajZFiFz9tsULz15CdC8Hvq9+gRPGXz5/Tw==','Aw==', '100', NULL, NULL, N'vql+JL9xC7mlfVoF4oThT+og65m09IcOD3X0bPrgO0PWTLMjCKGR0zm0Fs4eCvBQKHDX4c0h2/AdGYvZkvCcJg==', N'D:\\facture_homes\\DEMO\\in\\flat\\caf_2317.xml', N'DBNET INGENIERIA DE SOFTWARE S A', NULL, NULL, CAST(N'2023-04-11 00:00:00.000' AS DateTime))";

            return CAF33;

        }

        public String Dte_enca_docu_hold() { 

          String Dte_rang_foli= "' INSERT dte_enca_docu_hold(codi_emex,codi_empr,tipo_docu,foli_docu,esta_docu,mens_esta,corr_envi,mens_envi,fech_emis,entr_bien,vent_serv,form_pago,fech_canc," +
                                               "dias_tepa,codi_tepa,mont_brut,moda_pago,fech_venc,rutt_emis,peri_desd,peri_hast,digi_emis,nomb_emis,giro_emis,nomb_sucu,codi_sucu,dire_orig,comu_orig,ciud_orig," +
                                               "codi_vend,rutt_mand,digi_mand,rutt_rece,digi_rece,nomb_rece,codi_rece,giro_rece,cont_rece,dire_rece,comu_rece,ciud_rece,dire_post,comu_post,ciud_post,rutt_sofa," +
                                               "digi_sofa,info_tran,rutt_tran,digi_tran,dire_dest,comu_dest,ciud_dest,mont_neto,mont_exen,impu_vaag,impu_vanr,cred_es65,gara_enva,mont_tota,mont_nofa,valo_paga," +
                                               "sald_ante,codi_ceco,feho_firm,indi_vegd,vers_enca,feho_ted,firm_ted,fech_carg,usua_impr,nume_impr,fech_impr,vige_docu,codi_peri,corr_envi1,esta_docu1," +
                                               "mnsg_erro,indi_nore,subt_vese,dire_arch,impr_dest,val1,val2,val3,val4,val5,val6,val7,val8,val9,tasa_vaag,mont_base,cola_proc,nume_imme,arch_resp,tipo_impr,mont_canc," +
                                               "sald_inso,from_paex,tipo_cupa,cuen_pago,banc_pago,glos_pago,codi_emtr,foli_auto,fech_auto,codi_suad,iden_adem,iden_reex,naci_ext,iden_adre,mail_rece,rutt_chof," +
                                               "digi_chof,nomb_chof,moda_vent,clau_expo,tota_clex,viaa_tran,nomb_tran,rutt_citr,digi_citr,nomb_citr,iden_citr,nume_book,codi_oper,codi_puem,iden_puem,codi_pude," +
                                               "iden_pude,cant_tara,umed_tara,tota_brut,unid_brut,tota_neto,unid_neto,tota_item,tota_bult,mont_flet,mont_segu,pais_rece,pais_dest,tipo_moto,mont_baco,ivag_prop," +
                                               "ivag_terc,valo_cone,valo_coex,ivaag_core,tipo_moom,tipo_camb,neto_otmo,noaf_otmo,faca_otmo,maco_otmo,ivag_otmo,ivno_otmo,mont_otmo,tipo_mone,hace_envi,foli_clie," +
                                               "corr_extr,codi_mone,codi_usua,comi_neto,comi_exen,comi_ivaa,codi_serv,corr_cert_Firm,codi_form,peri_part,lote_docu,esta_reme,even_recl,docu_escd,tran_vent,tran_comp," +
                                               "TIPO_FAES,TIPO_TURI) VALUES ";
            return Dte_rang_foli;
        }

        public String Dte_enca_docu_hold33()
        {

            String Dte_rang_foli = "'INSERT INTO dte_enca_docu_hold (codi_emex,codi_empr, tipo_docu, vers_enca, foli_clie, feho_ted, feho_firm,foli_docu, fech_emis, indi_nore,entr_bien, indi_vegd, vent_serv, mont_brut," +
                                      "form_pago, fech_canc, peri_desd, peri_hast, moda_pago, codi_tepa, dias_tepa, fech_venc, rutt_emis, digi_emis, nomb_emis, giro_emis, nomb_sucu, codi_sucu, dire_orig," +
                                      "comu_orig, ciud_orig, codi_vend, rutt_mand, digi_mand, rutt_rece, digi_rece, codi_rece,nomb_rece, giro_rece, cont_rece, dire_rece, comu_rece, ciud_rece, dire_post," +
                                      "comu_post, ciud_post,rutt_sofa, digi_sofa, info_tran, rutt_tran, digi_tran, dire_dest, comu_dest, ciud_dest, mont_neto, mont_exen, mont_base, tasa_vaag,impu_vaag," +
                                      "impu_vanr, cred_es65, gara_enva, mont_tota, mont_nofa, subt_vese, sald_ante, valo_paga, esta_docu, mnsg_erro, tipo_impr, mont_canc, sald_inso, from_paex, tipo_cupa," +
                                      "cuen_pago, banc_pago, glos_pago, codi_emtr, foli_auto, fech_auto, codi_suad, iden_adem, iden_reex, naci_ext, iden_adre, mail_rece, rutt_chof, digi_chof, nomb_chof," +
                                      "moda_vent, clau_expo, tota_clex, viaa_tran, nomb_tran, rutt_citr, digi_citr, nomb_citr, iden_citr, nume_book, codi_oper, codi_puem, iden_puem, codi_pude, iden_pude," +
                                      "cant_tara, umed_tara, tota_brut, unid_brut, tota_neto, unid_neto, tota_item, tota_bult, mont_flet, mont_segu, pais_rece, pais_dest, tipo_mone, mont_baco, ivag_prop," +
                                      "ivag_terc, tipo_moom, tipo_camb, neto_otmo, noaf_otmo, faca_otmo, maco_otmo, ivag_otmo, ivno_otmo, mont_otmo, impr_dest, val1, val2, val3, val4, val5, val6, val7, val8," +
                                      "val9, nume_impr, nume_imme, cola_proc, tran_vent, tran_comp, tipo_faes, tipo_turi) VALUES  ";
            return Dte_rang_foli;
        }
        public String Dte_enca_docu_hold43()
        {

            String Dte_rang_foli43 = "' INSERT INTO dte_enca_docu_hold (codi_emex,codi_empr, tipo_docu, vers_enca, foli_clie, feho_ted, feho_firm, foli_docu, fech_emis, indi_nore, entr_bien, indi_vegd, vent_serv, mont_brut, form_pago, fech_canc, peri_desd, peri_hast, moda_pago," +
                                              "codi_tepa, dias_tepa, fech_venc, rutt_emis, digi_emis, nomb_emis, giro_emis, nomb_sucu, codi_sucu, dire_orig, comu_orig, ciud_orig, codi_vend, rutt_mand, digi_mand, rutt_rece, digi_rece, codi_rece, nomb_rece, giro_rece," +
                                              "cont_rece, dire_rece, comu_rece, ciud_rece, dire_post, comu_post, ciud_post, rutt_sofa, digi_sofa, info_tran, rutt_tran, digi_tran, dire_dest, comu_dest, ciud_dest, mont_neto, mont_exen, mont_base, tasa_vaag, impu_vaag," +
                                              "impu_vanr, cred_es65, gara_enva, mont_tota, mont_nofa, subt_vese, sald_ante, valo_paga, esta_docu, mnsg_erro, tipo_impr, mont_canc, sald_inso, from_paex, tipo_cupa, cuen_pago, banc_pago, glos_pago, codi_emtr, foli_auto," +
                                              "fech_auto, codi_suad, iden_adem, iden_reex, naci_ext, iden_adre, mail_rece, rutt_chof, digi_chof, nomb_chof, moda_vent, clau_expo, tota_clex, viaa_tran, nomb_tran, rutt_citr, digi_citr, nomb_citr, iden_citr, nume_book, " +
                                              "codi_oper, codi_puem, iden_puem, codi_pude, iden_pude, cant_tara, umed_tara, tota_brut, unid_brut, tota_neto, unid_neto, tota_item, tota_bult, mont_flet, mont_segu, pais_rece, pais_dest, tipo_mone, mont_baco, ivag_prop," +
                                              "ivag_terc, tipo_moom, tipo_camb, neto_otmo, noaf_otmo, faca_otmo, maco_otmo, ivag_otmo, ivno_otmo, mont_otmo, impr_dest, val1, val2, val3, val4, val5, val6, val7, val8, val9, nume_impr, nume_imme, cola_proc, tran_vent, " +
                                              "tran_comp, tipo_faes, tipo_turi) VALUES";
            return Dte_rang_foli43;
        }

        public String Dte_enca_docu_oracle()
        {

            String dte_enca_docu = " INSERT into dte_enca_docu (codi_empr,tipo_docu, foli_docu, esta_docu, mens_esta, corr_envi, mens_envi, fech_emis, entr_bien, vent_serv, form_pago, fech_canc, dias_tepa, codi_tepa, mont_brut, " +
                                           "moda_pago, fech_venc, rutt_emis, peri_desd, peri_hast, digi_emis, nomb_emis, giro_emis, nomb_sucu , codi_sucu , dire_orig, comu_orig, ciud_orig, codi_vend, rutt_mand, digi_mand, rutt_rece, " +
                                           "digi_rece, nomb_rece, codi_rece, giro_rece, cont_rece, dire_rece, comu_rece, ciud_rece, dire_post , comu_post , ciud_post, rutt_sofa, digi_sofa, info_tran, rutt_tran, digi_tran, dire_dest, " +
                                           "comu_dest, ciud_dest, mont_neto, mont_exen, impu_vaag, impu_vanr, cred_es65, gara_enva, mont_tota , mont_nofa , valo_paga, sald_ante, codi_ceco, feho_firm, indi_vegd, vers_enca, " +
                                           "feho_ted ,  firm_ted, fech_carg, usua_impr, nume_impr, fech_impr, vige_docu, codi_peri, corr_envi1, esta_docu1, mnsg_erro, indi_nore, subt_vese, dire_arch, impr_dest, val1, val2, val3, " +
                                           "val4 ,  val5 ,  val6, val7, val8, val9, tasa_vaag, mont_base, cola_proc, nume_imme, arch_resp , hace_envi , tipo_impr, mont_canc, sald_inso, from_paex, tipo_cupa, cuen_pago, banc_pago, " +
                                           "glos_pago, codi_emtr, foli_auto, fech_auto, codi_suad, iden_adem, iden_reex, naci_ext  , iden_adre , mail_rece, rutt_chof, digi_chof, nomb_chof, moda_vent, clau_expo, tota_clex, viaa_tran, " +
                                           "nomb_tran, rutt_citr, digi_citr, nomb_citr, iden_citr, nume_book, codi_oper, codi_puem , iden_puem , codi_pude, iden_pude, cant_tara, umed_tara, tota_brut, unid_brut, tota_neto, unid_neto," +
                                           "tota_item, tota_bult, mont_flet, mont_segu, pais_rece, pais_dest, tipo_mone, mont_baco , ivag_prop , ivag_terc, valo_cone, valo_coex, ivaag_core,tipo_moom, tipo_camb, neto_otmo, noaf_otmo," +
                                           "faca_otmo, maco_otmo, ivag_otmo, ivno_otmo, mont_otmo, foli_clie, corr_extr, codi_usua , comi_neto , comi_exen, comi_ivaa, codi_emex, lote_docu, codi_serv, corr_cert_Firm, codi_form, peri_part," +
                                           "esta_reme, even_recl, docu_escd, tran_vent, tran_comp, TIPO_FAES, TIPO_TURI) VALUES  ";
            return dte_enca_docu;
        }

        public String dte_docu_refe_oracle()
        {

            String dte_docu_refe = " INSERT into dte_docu_refe (codi_empr, tipo_docu, foli_docu, nume_refe, tipo_refe, foli_refe, rutt_otro, digi_otro, fech_refe, razo_refe, codi_refe, indi_regl, mnsg_erro, foli_clie, codi_emex, peri_part) VALUES ";
            return dte_docu_refe;
        }

        public String Dte_docu_refe_hold()
        {
            String deficion_dte_docu_refe = "INSERT dte_docu_refe_hold (codi_emex,codi_empr,tipo_docu,foli_docu,nume_refe,tipo_refe,foli_refe,rutt_otro,digi_otro,fech_refe,razo_refe,codi_refe,indi_regl,mnsg_erro,foli_clie,peri_part) VALUES ";
            return deficion_dte_docu_refe;
        }

        public String Dbq_arch() {
            String dbq_archx = "INSERT [dbo].[DBQ_ARCH] ( [CODI_GRPO], [ESTA_ARCH], [CTRL_ARCH], [CODI_SERV], [CODI_SERV_ORIG], [TMST_REGI_ARCH], [TMST_PROC_ARCH], [CONT_PROC_ARCH], [NOMB_ARCH], [EXTE_ARCH], [TIPO_ARCH], [SUBT_ARCH], [TABL_RELA], [PK01_TABL], [PK02_TABL], [PK03_TABL], [PK04_TABL], [PK05_TABL], [PK06_TABL], [TABL_ESTA], [ULTI_ERRO], [TIPO_REGI], [LOTE_ARCH]) VALUES ";
            return dbq_archx;
        }

        public String Dbq_arch_clob() {
            String dbq_arch_clobx = "INSERT [dbo].[DBQ_ARCH_CLOB] ([CODI_ARCH], [CLOB_ARCH]) VALUES ";
            return dbq_arch_clobx;
        }
        public String qmta_rece_info() {

            String qmta_rece_infoX = "INSERT[qmta_rece_info]( [mail_msid],[mail_from], [mail_into], [mail_incc], [mail_subj], [mail_cdat], [mail_esta], [mail_msge], [mail_fing], [fech_proc], [nmro_rtry]) values";
            return qmta_rece_infoX;
        }
        public String qmta_rece_part()
        {

            String qmta_rece_partx = "INSERT [dbo].[qmta_rece_part] ([mail_msid], [part_txml], [part_filn], [part_type],[part_cset], [part_cb64], [part_esta], [part_msge], [part_fing]) values  ";
            return qmta_rece_partx;
        }
        public String BEL_ENCA_DOCU_HOLD() {
            String BEL_ENCA_DOCU = "INSERT INTO BEL_ENCA_DOCU_HOLD (codi_emex,CODI_EMPR, TIPO_DOCU, FOLI_DOCU, VERS_ENCA, ESTA_DOCU, FECH_EMIS, INDI_SERV, INDI_MONE, PEDI_DESD, PERI_HAST, FECH_VENC, RUTT_EMIS, DIGI_VERI, NOMB_EMIS, GIRO_EMIS, CODI_SUCU, DIRE_ORIG, COMU_ORIG, CIUD_ORIG, RUTT_RECE, DIGI_RECE, CODI_INTE, NOMB_RECE, CONT_RECE, DIRE_RECE, COMU_RECE, CIUD_RECE, DIRE_POST, COMU_POST, CIUD_POST, MONT_NETO, MONT_EXEN, TASA_VAAG,IMPU_VAAG, MONT_TOTA, MONT_NOFA, TOTA_PERI, SALD_ANTE, VALO_PAGA, TMST_TIMB, VAL1, VAL2, VAL3, VAL4,VAL5, VAL6, VAL7, VAL8, VAL9, VAL10, NUME_IMPR, FOLI_CLIE, CODI_USUA, PUNT_EMIS, LOCA_EMIS, FORM_PAGO, MEDI_PAGO, ENCA_NEGO, IDEN_CLIE, IMPR_DEST,cola_proc)VALUES ";
            return BEL_ENCA_DOCU;
        }

        public String BEL_DETA_PRSE_HOLD()
        {
            String BEL_DETA_PRSE = "INSERT INTO BEL_DETA_PRSE_HOLD (codi_emex,CODI_EMPR, FOLI_DOCU, TIPO_DOCU, NUME_LINE, INDI_EXEN, NOMB_ITEM, DESC_ADIC, CANT_ITEM, UNID_MED, PREC_UNIC, VALO_LINE, PORC_DESC, MONT_DESC,PORC_RECA, MONT_RECA ) VALUES ";
            return BEL_DETA_PRSE;
        }

        public String BEL_ENCA_DOCU_SQLINHOUSE()
        {
            String BEL_ENCA_DOCU = "INSERT INTO BEL_ENCA_DOCU (CODI_EMPR, TIPO_DOCU, FOLI_DOCU, VERS_ENCA, ESTA_DOCU, FECH_EMIS, INDI_SERV, INDI_MONE, PEDI_DESD, PERI_HAST, FECH_VENC, RUTT_EMIS, DIGI_VERI, NOMB_EMIS, GIRO_EMIS, CODI_SUCU, DIRE_ORIG, COMU_ORIG, CIUD_ORIG, RUTT_RECE, DIGI_RECE, CODI_INTE, NOMB_RECE, CONT_RECE, DIRE_RECE, COMU_RECE, CIUD_RECE, DIRE_POST, COMU_POST, CIUD_POST, MONT_NETO, MONT_EXEN, TASA_VAAG,IMPU_VAAG, MONT_TOTA, MONT_NOFA, TOTA_PERI, SALD_ANTE, VALO_PAGA, TMST_TIMB, VAL1, VAL2, VAL3, VAL4,VAL5, VAL6, VAL7, VAL8, VAL9, VAL10, NUME_IMPR, FOLI_CLIE, CODI_USUA, PUNT_EMIS, LOCA_EMIS, FORM_PAGO, MEDI_PAGO, ENCA_NEGO, IDEN_CLIE, IMPR_DEST,cola_proc)VALUES ";
            return BEL_ENCA_DOCU;
        }

        public String BEL_DETA_PRSE_SQLINHOUSE()
        {
            String BEL_DETA_PRSE = "INSERT INTO BEL_DETA_PRSE (CODI_EMPR, FOLI_DOCU, TIPO_DOCU, NUME_LINE, INDI_EXEN, NOMB_ITEM, DESC_ADIC, CANT_ITEM, UNID_MED, PREC_UNIC, VALO_LINE, PORC_DESC, MONT_DESC,PORC_RECA, MONT_RECA ) VALUES  ";
            return BEL_DETA_PRSE;
        }

        public String BEL_DETA_CODI_SQLINHOUSE()
        {
            String BEL_DETA_CODI = "INSERT INTO BEL_DETA_CODI (CODI_EMPR, TIPO_DOCU, FOLI_DOCU, NUME_LINE, TIPO_CODI, CODI_ITEM) VALUES  ";
            return BEL_DETA_CODI;
        }
        public String BEL_ENCA_DOCU_oracle()
        {
            String BEL_ENCA_DOCU = "INSERT INTO BEL_ENCA_DOCU (CODI_EMPR, TIPO_DOCU, FOLI_DOCU, VERS_ENCA, ESTA_DOCU, FECH_EMIS, INDI_SERV, INDI_MONE, PEDI_DESD, PERI_HAST, FECH_VENC, RUTT_EMIS, DIGI_VERI, NOMB_EMIS, GIRO_EMIS, CODI_SUCU, DIRE_ORIG, COMU_ORIG, CIUD_ORIG, RUTT_RECE, DIGI_RECE, CODI_INTE, NOMB_RECE, CONT_RECE, DIRE_RECE, COMU_RECE, CIUD_RECE, DIRE_POST, COMU_POST, CIUD_POST, MONT_NETO, MONT_EXEN, TASA_VAAG,IMPU_VAAG, MONT_TOTA, MONT_NOFA, TOTA_PERI, SALD_ANTE, VALO_PAGA, TMST_TIMB, VAL1, VAL2, VAL3, VAL4,VAL5, VAL6, VAL7, VAL8, VAL9, VAL10, NUME_IMPR, FOLI_CLIE, CODI_USUA, PUNT_EMIS, LOCA_EMIS, FORM_PAGO, MEDI_PAGO, ENCA_NEGO, IDEN_CLIE, IMPR_DEST,cola_proc)VALUES  ";
            return BEL_ENCA_DOCU;
        }

        public String BEL_DETA_PRSE_Oracle()
        {
            String BEL_DETA_PRSE = "INSERT INTO BEL_DETA_PRSE (CODI_EMPR, FOLI_DOCU, TIPO_DOCU, NUME_LINE, INDI_EXEN, NOMB_ITEM, DESC_ADIC, CANT_ITEM, UNID_MED, PREC_UNIC, VALO_LINE, PORC_DESC, MONT_DESC,PORC_RECA, MONT_RECA ) VALUES  ";
            return BEL_DETA_PRSE;
        }

        public String BEL_DETA_CODI_Oracle()
        {
            String BEL_DETA_CODI = "INSERT INTO BEL_DETA_CODI (CODI_EMPR, TIPO_DOCU, FOLI_DOCU, NUME_LINE, TIPO_CODI, CODI_ITEM) VALUES ";
            return BEL_DETA_CODI;
        }

        public String BEL_DETA_CODI_HOLD()
        {
            String BEL_DETA_CODI = "INSERT INTO BEL_DETA_CODI_HOLD (codi_emex,CODI_EMPR, TIPO_DOCU, FOLI_DOCU, NUME_LINE, TIPO_CODI, CODI_ITEM) VALUES ";
            return BEL_DETA_CODI;
        }

        public String dte_temp_CF()
        {
            String dte_temp = "INSERT[dbo].[dte_temp]( [TIPO_OPER], [TIPO_FUEN], [PERI_TRIB], [RUTT_EMIS], [DIGI_EMIS], [RAZO_EMIS], [TIPO_EMIS], [RUTT_RECE], [DIGI_RECE], [RAZO_RECE], [TIPO_DOCU], [FOLI_DOCU], [FECH_EMIS]," +
                              "[CORR_DOCU_DTO], [FECH_RECE_SII], [FECH_INFO_SII], [NUME_ATEN_SII], [FECH_CARG_SUIT], [USUA_RESP_COME], [MOTI_REPA_COME], [ESTA_DOCU_RCBM], [FECH_DOCU_RCBM], [MONT_NETO], [MONT_EXEN], [MONT_IVA], [MONT_TOTA]," +
                              "[ORDE_COMP], [NUME_ORCM], [TIPO_COVE], [MONT_ISIR], [MONT_INOR], [CODI_INOR], [MONT_NACF], [IVAA_ACFI], [IVAU_COMU], [IMPU_SDAC], [IVAN_NORE], [TABA_PURO], [TABA_CIGA], [TABA_ELAB], [NOCD_SFCO], [IVAR_TOTA]," +
                              "[IVAR_PARC], [IVAN_RETE], [IVAP_PROP], [IVAT_TERC], [RUTT_ELFA], [DIGI_ELFA], [NETO_CLFA], [EXEN_CLFA], [IVAA_CLFA], [IVAA_FDPL], [TICO_REFE], [FODO_REFE], [NUMM_IREX], [NACI_REEX], [CRED_EMCO], [IMPT_ZOFR]," +
                              "[GARA_DEEN], [INDI_VSCO], [INDI_SEPE], [MONT_NOFA], [TOTA_MOPE], [VEPA_TRNA], [VEPA_TRIN], [NUME_INTE], [CODI_SUCU], [CORR_ARCH], [CODI_OIMP], [VALO_OIMP], [PORC_OIMP], [ESTA_REAC], [FECH_REAC], [TIPO_COMP]) VALUES ";
            return dte_temp;
        }

        public String dte_control_CF()
        {
            String dte_control = "INSERT [dbo].[dte_control] ( [TIPO_OPER], [RUTT_EMIS], [DIGI_EMIS], [RAZO_EMIS], [TIPO_EMIS], [RUTT_RECE], [DIGI_RECE], [RAZO_RECE], [TIPO_DOCU], [FOLI_DOCU], [FECH_EMIS], [CORR_DOCU_DTO]," +
                                 "[ESTA_RECE_SII], [FECH_RECE_SII], [FECH_INFO_SII], [NUME_ATEN_SII], [CORR_ARCH_DTE], [ESTA_CARG_SUIT], [FECH_CARG_SUIT], [ESTA_RCAC_SII], [FECH_RCAC_SII], [ESTA_CESI_SII], [FECH_CESI_SII], [MONT_CESI_SII]," +
                                 "[RUTT_CESI_SII], [DIGI_CESI_SII], [RAZO_CESI_SII], [CORR_ARCH_CESI], [ESTA_DOCU_COME], [FECH_DOCU_COME], [USUA_RESP_COME], [MOTI_REPA_COME], [ESTA_DOCU_RCBM], [FECH_DOCU_RCBM], [MONT_NETO], [MONT_EXEN]," +
                                 "[MONT_IVA], [MONT_TOTA], [MONT_TOTA_SII], [ORDE_COMP], [NUME_ORCM], [ESTA_DOCU_TECN], [FECH_DOCU_TECN], [MOTI_REPA_TECN], [ESTA_ENVI_SII], [FECH_ENVI_SII], [ESTA_ENVI_CLI], [FECH_ENVI_CLI], [mont_neto_sii]," +
                                 "[mont_exen_sii], [mont_iva_sii], [codi_otro_sii], [valo_otro_sii], [tasa_otro_sii], [TIPO_COVE], [MONT_ISIR], [MONT_INOR], [CODI_INOR], [MONT_NACF], [IVAA_ACFI], [IVAU_COMU], [IMPU_SDAC], [IVAN_NORE]," +
                                 "[TABA_PURO], [TABA_CIGA], [TABA_ELAB], [NOCD_SFCO], [PERI_TRIB], [IVAR_TOTA], [IVAR_PARC], [IVAN_RETE], [IVAP_PROP], [IVAT_TERC], [RUTT_ELFA], [DIGI_ELFA], [NETO_CLFA], [EXEN_CLFA], [IVAA_CLFA], [IVAA_FDPL]," +
                                 "[TICO_REFE], [FODO_REFE], [NUMM_IREX], [NACI_REEX], [CRED_EMCO], [IMPT_ZOFR], [GARA_DEEN], [INDI_VSCO], [INDI_SEPE], [MONT_NOFA], [TOTA_MOPE], [VEPA_TRNA], [VEPA_TRIN], [NUME_INTE], [CODI_SUCU], [ESTA_RCV]," +
                                 "[DTEC_NELE], [TIPO_COMP]) VALUES";
            return dte_control;
        }

        public String dte_envi_pdf_hold()
        {
            String dte_envi_pdf = "INSERT [dbo].[dte_envi_pdf_hold] ([codi_emex], [codi_empr], [tipo_docu], [foli_docu], [posi_mail], [mail_envi], [mail_cc], [mail_cco], [mail_text], [hace_envi], [ESTA_MLPR], [MAPE_FROM], [MAPE_REF], [peri_part]) VALUES ";
            return dte_envi_pdf;
        }

        public String ARCH_DTE_INFO_SII_CF()
        {
            String ARCH_DTE_INFO_SII = "INSERT [dbo].[ARCH_DTE_INFO_SII] ( [CODI_EMPR], [NOMB_ARCH], [TIPO_ARCH], [FECH_CARG], [ESTA_CARG], [MENS_CARG], [RUTT_EMPR], [DIGI_EMPR], [NOMB_COME], [TOTA_ARCH], [TOTA_SKIP],[TOTA_CARG], [TOTA_RECH]) VALUES";
            return ARCH_DTE_INFO_SII;
        }

        public String dte_cesion_sii_tmp_CF()
        {
            String dte_cesion_sii_tmp = "INSERT [dbo].[dte_cesion_sii_tmp] ([CORR_ARCH], [CODI_EMPR], [RUTT_VEND], [DIGI_VEND], [ESTA_CESI], [RUTT_DEUD], [DIGI_DEUD], [MAIL_DEUD], [TIPO_DOCU], [NOMB_DOCU], [FOLI_DOCU], [FECH_EMIS], [MONT_TOTA], [RUTT_CEDE], [DIGI_CEDE], [RAZO_CEDE], [MAIL_CEDE], [RUTT_CESI], [DIGI_CESI], [RAZO_CESI], [MAIL_CESI], [FECH_CESI], [MONT_CESI], [FECH_VENC]) VALUES ";
            return dte_cesion_sii_tmp;
        }
        public String PRCCARGADTE(int Tipo_docu, int diferencia, String Hold,string RutEmpresa, String DigiEmpresa)
        {
            String Carga = "DECLARE	@return_value int \n" +
                                                   "EXEC @return_value = [dbo].[Carga_Documentos] \n" +
                                                   "        @CantidadCargar =  '" + diferencia + "', \n" +
                                                   "		@Tipo_docu = '" + Tipo_docu + "', \n" +
                                                   "		@Holding = '" + Hold + "' ,\n" +
                                                   "		@RutEmisor = " + RutEmpresa + ",\n" +
                                                   "		@digi = '" + DigiEmpresa + "' \n" +
                                                   "SELECT  'Return Value' = @return_value ";
            return Carga;
        }

        public String creaDirectorio(String ruta)
        {
            if (!System.IO.Directory.Exists(ruta))
            {
                System.IO.Directory.CreateDirectory(ruta);
            }
            return ruta;
        }
    }
}
