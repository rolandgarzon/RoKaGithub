using System;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using RoKa.Models;
using Microsoft.VisualBasic.FileIO;
using System.Web;
using System.IO;

namespace RoKa.Controllers
{
    public class rk_lecturaController : Controller
    {
        private ContextRoKa db = new ContextRoKa();

        // GET: rk_lectura
        public ActionResult Index()
        {
            var rk_lectura = db.rk_lectura.Include(r => r.rk_causalectura).Include(r => r.rk_ciclofacturacion).Include(r => r.rk_departamento).Include(r => r.rk_estadolectura).Include(r => r.rk_municipio).Include(r => r.rk_observacioneslectura).Include(r => r.rk_pais).Include(r => r.rk_servicio).Include(r => r.rk_tecnico).Include(r => r.rk_terminalportatil).Include(r => r.rk_usuario);
            return View(rk_lectura.ToList());
        }

        // GET: rk_lectura/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            rk_lectura rk_lectura = db.rk_lectura.Find(id);
            if (rk_lectura == null)
            {
                return HttpNotFound();
            }
            return View(rk_lectura);
        }

        // GET: rk_lectura/Create
        public ActionResult Create()
        {
            ViewBag.idcausalectura = new SelectList(db.rk_causalectura, "idcausalectura", "descripcion");
            ViewBag.idciclofacturacion = new SelectList(db.rk_ciclofacturacion, "idciclofacturacion", "descripcion");
            ViewBag.iddepartamento = new SelectList(db.rk_departamento, "iddepartamento", "descripcion");
            ViewBag.idestadolectura = new SelectList(db.rk_estadolectura, "idestadolectura", "descripcion");
            ViewBag.idmunicipio = new SelectList(db.rk_municipio, "idmunicipio", "descripcion");
            ViewBag.idobservacionlectura = new SelectList(db.rk_observacioneslectura, "idobservacionlectura", "descripcion");
            ViewBag.idpais = new SelectList(db.rk_pais, "idpais", "descripcion");
            ViewBag.idservicio = new SelectList(db.rk_servicio, "idservicio", "descripcion");
            ViewBag.idtecnico = new SelectList(db.rk_tecnico, "idtecnico", "identificacion");
            ViewBag.idterminalportatil = new SelectList(db.rk_terminalportatil, "idterminalportatil", "serie");
            ViewBag.idusuario = new SelectList(db.rk_usuario, "idusuario", "nombrecompleto");
            return View();
        }

        // POST: rk_lectura/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idlectura,idpais,iddepartamento,idmunicipio,idservicio,idciclofacturacion,ano,mes,idsuscriptor,nombre,direccion,rutalectura,lecturatomada,idobservacionlectura,idcausalectura,fechatomalectura,informacionadicional,lecturafacturada,observacionfacturada,idtecnico,lecturaanterior,consumofacturado,consumopromedio,mesesdesacumulados,idusuario,idobservacionlectant,fechamodificacion,idvigencia,idterminalportatil,idestadolectura,fechalecturatomada,idmedidor")] rk_lectura rk_lectura)
        {
            if (ModelState.IsValid)
            {
                db.rk_lectura.Add(rk_lectura);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idcausalectura = new SelectList(db.rk_causalectura, "idcausalectura", "descripcion", rk_lectura.idcausalectura);
            ViewBag.idciclofacturacion = new SelectList(db.rk_ciclofacturacion, "idciclofacturacion", "descripcion", rk_lectura.idciclofacturacion);
            ViewBag.iddepartamento = new SelectList(db.rk_departamento, "iddepartamento", "descripcion", rk_lectura.iddepartamento);
            ViewBag.idestadolectura = new SelectList(db.rk_estadolectura, "idestadolectura", "descripcion", rk_lectura.idestadolectura);
            ViewBag.idmunicipio = new SelectList(db.rk_municipio, "idmunicipio", "descripcion", rk_lectura.idmunicipio);
            ViewBag.idobservacionlectura = new SelectList(db.rk_observacioneslectura, "idobservacionlectura", "descripcion", rk_lectura.idobservacionlectura);
            ViewBag.idpais = new SelectList(db.rk_pais, "idpais", "descripcion", rk_lectura.idpais);
            ViewBag.idservicio = new SelectList(db.rk_servicio, "idservicio", "descripcion", rk_lectura.idservicio);
            ViewBag.idtecnico = new SelectList(db.rk_tecnico, "idtecnico", "identificacion", rk_lectura.idtecnico);
            ViewBag.idterminalportatil = new SelectList(db.rk_terminalportatil, "idterminalportatil", "serie", rk_lectura.idterminalportatil);
            ViewBag.idusuario = new SelectList(db.rk_usuario, "idusuario", "nombrecompleto", rk_lectura.idusuario);
            return View(rk_lectura);
        }

        // GET: rk_lectura/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            rk_lectura rk_lectura = db.rk_lectura.Find(id);
            if (rk_lectura == null)
            {
                return HttpNotFound();
            }
            ViewBag.idcausalectura = new SelectList(db.rk_causalectura, "idcausalectura", "descripcion", rk_lectura.idcausalectura);
            ViewBag.idciclofacturacion = new SelectList(db.rk_ciclofacturacion, "idciclofacturacion", "descripcion", rk_lectura.idciclofacturacion);
            ViewBag.iddepartamento = new SelectList(db.rk_departamento, "iddepartamento", "descripcion", rk_lectura.iddepartamento);
            ViewBag.idestadolectura = new SelectList(db.rk_estadolectura, "idestadolectura", "descripcion", rk_lectura.idestadolectura);
            ViewBag.idmunicipio = new SelectList(db.rk_municipio, "idmunicipio", "descripcion", rk_lectura.idmunicipio);
            ViewBag.idobservacionlectura = new SelectList(db.rk_observacioneslectura, "idobservacionlectura", "descripcion", rk_lectura.idobservacionlectura);
            ViewBag.idpais = new SelectList(db.rk_pais, "idpais", "descripcion", rk_lectura.idpais);
            ViewBag.idservicio = new SelectList(db.rk_servicio, "idservicio", "descripcion", rk_lectura.idservicio);
            ViewBag.idtecnico = new SelectList(db.rk_tecnico, "idtecnico", "identificacion", rk_lectura.idtecnico);
            ViewBag.idterminalportatil = new SelectList(db.rk_terminalportatil, "idterminalportatil", "serie", rk_lectura.idterminalportatil);
            ViewBag.idusuario = new SelectList(db.rk_usuario, "idusuario", "nombrecompleto", rk_lectura.idusuario);
            return View(rk_lectura);
        }

        // POST: rk_lectura/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idlectura,idpais,iddepartamento,idmunicipio,idservicio,idciclofacturacion,ano,mes,idsuscriptor,nombre,direccion,rutalectura,lecturatomada,idobservacionlectura,idcausalectura,fechatomalectura,informacionadicional,lecturafacturada,observacionfacturada,idtecnico,lecturaanterior,consumofacturado,consumopromedio,mesesdesacumulados,idusuario,idobservacionlectant,fechamodificacion,idvigencia,idterminalportatil,idestadolectura,fechalecturatomada,idmedidor")] rk_lectura rk_lectura)
        {
            if (ModelState.IsValid)
            {
                db.Entry(rk_lectura).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idcausalectura = new SelectList(db.rk_causalectura, "idcausalectura", "descripcion", rk_lectura.idcausalectura);
            ViewBag.idciclofacturacion = new SelectList(db.rk_ciclofacturacion, "idciclofacturacion", "descripcion", rk_lectura.idciclofacturacion);
            ViewBag.iddepartamento = new SelectList(db.rk_departamento, "iddepartamento", "descripcion", rk_lectura.iddepartamento);
            ViewBag.idestadolectura = new SelectList(db.rk_estadolectura, "idestadolectura", "descripcion", rk_lectura.idestadolectura);
            ViewBag.idmunicipio = new SelectList(db.rk_municipio, "idmunicipio", "descripcion", rk_lectura.idmunicipio);
            ViewBag.idobservacionlectura = new SelectList(db.rk_observacioneslectura, "idobservacionlectura", "descripcion", rk_lectura.idobservacionlectura);
            ViewBag.idpais = new SelectList(db.rk_pais, "idpais", "descripcion", rk_lectura.idpais);
            ViewBag.idservicio = new SelectList(db.rk_servicio, "idservicio", "descripcion", rk_lectura.idservicio);
            ViewBag.idtecnico = new SelectList(db.rk_tecnico, "idtecnico", "identificacion", rk_lectura.idtecnico);
            ViewBag.idterminalportatil = new SelectList(db.rk_terminalportatil, "idterminalportatil", "serie", rk_lectura.idterminalportatil);
            ViewBag.idusuario = new SelectList(db.rk_usuario, "idusuario", "nombrecompleto", rk_lectura.idusuario);
            return View(rk_lectura);
        }

        // GET: rk_lectura/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            rk_lectura rk_lectura = db.rk_lectura.Find(id);
            if (rk_lectura == null)
            {
                return HttpNotFound();
            }
            return View(rk_lectura);
        }

        // POST: rk_lectura/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            rk_lectura rk_lectura = db.rk_lectura.Find(id);
            db.rk_lectura.Remove(rk_lectura);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        // GET: rk_Lectura/Cargar Archivo Plano
        public ActionResult CargarArchivoPlano()
        {
            ViewBag.terminalportatil = new SelectList(db.rk_terminalportatil.OrderBy(s=>s.idterminalportatil), "idterminalportatil", "serie");
            ViewBag.ciclofacturacion = new SelectList(db.rk_ciclofacturacion.OrderBy(s => s.idciclofacturacion), "idciclofacturacion", "descripcion");
            return View();
        }

        // POST: rk_usuario/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CargarArchivoPlano(HttpPostedFileBase archivolectura,string terminalportatil, string ano, string mes, string ciclofacturacion)
        {
            ViewBag.terminalportatil = new SelectList(db.rk_terminalportatil.OrderBy(s => s.idterminalportatil), "idterminalportatil", "serie");
            ViewBag.ciclofacturacion = new SelectList(db.rk_ciclofacturacion.OrderBy(s => s.idciclofacturacion), "idciclofacturacion", "descripcion");

            if(string.IsNullOrEmpty(ano))
            {
                ModelState.AddModelError("ano", "El campo año es obligatorio");
            }
            if (string.IsNullOrEmpty(mes))
            {
                ModelState.AddModelError("mes", "El campo mes es obligatorio");
            }
            if (ModelState.IsValid)
            {
                //try
                //{
                    if (archivolectura == null) return View();

                    archivolectura.SaveAs(Server.MapPath("~/archivolectura/" + archivolectura.FileName));
                    var path = Server.MapPath("~/archivolectura/" + archivolectura.FileName);

                    using (TextFieldParser csvParser = new TextFieldParser(path))
                    {
                        csvParser.CommentTokens = new string[] { "#" };
                        csvParser.SetDelimiters(new string[] { ";" });
                        csvParser.HasFieldsEnclosedInQuotes = true;
                        string vasuscriptorcompleto = "";
                        string vaidobservacionlectura = "0";
                        string vaobservacionfacturada = "0";
                        string vaidcausalectura = "33";
                        DateTime dafechatomalectura = DateTime.Now;
                        string vaidusuario = "94123456";
                        string vaidvigencia = "5776143";
                        string vaidestadolectura = "1";
                        string vaterminalportatil = terminalportatil;
                        string vaidtecnico = "94356648";

                        string vaidlectura = "";
                        string vaidpais = "";
                        string vaiddepartamento = "";
                        string vaidmunicipio = "";
                        string vaidservicio = "";
                        string vaidciclofacturacion = "";
                        string vaano = "";
                        string vames = "";
                        string vaidsuscripcion = "";
                        string valecturaanterior = "";
                        string vaconsumopromedio = "";
                        string vaidobservacionlectant = "";
                        string vanombre = "";
                        string vadireccion = "";
                        string vaidmedidor = "";
                        string varutalectura = "";
                        int idlectura = 0;
                        int errorlectura = 0;

                        // Skip the row with the column names
                        //csvParser.ReadLine();
                        while (!csvParser.EndOfData)
                        {
                            // Read current line fields, pointer moves to the next line.
                            string[] fields = csvParser.ReadFields();
                            //vaidlectura = Convert.ToString(idlectura);
                            vaidpais = fields[7];
                            vaiddepartamento = fields[8];
                            vaidmunicipio = fields[9];
                            vaidservicio = fields[13];
                            vaidciclofacturacion = fields[10];
                            vaano = fields[11];
                            vames = fields[12];
                            vaidsuscripcion = fields[4];
                            valecturaanterior = fields[6];
                            vaconsumopromedio = fields[5];
                            //vaidobservacionlectant = fields[13];
                            vaidobservacionlectant = "1";
                            vanombre = fields[0];
                            vadireccion = fields[1];
                            vaidmedidor = fields[2];
                            varutalectura = fields[3];

                            vasuscriptorcompleto = vaidpais + vaiddepartamento + vaidmunicipio + vaidsuscripcion;
                            rk_lectura objrk_lectura = new rk_lectura();
                            //objrk_lectura.idlectura = vaidlectura;
                            objrk_lectura.idpais = vaidpais;
                            objrk_lectura.iddepartamento = vaiddepartamento;
                            objrk_lectura.idmunicipio = vaidmunicipio;
                            objrk_lectura.idservicio = vaidservicio;
                            objrk_lectura.idciclofacturacion = vaidciclofacturacion;
                            objrk_lectura.ano = vaano;
                            objrk_lectura.mes = vames;
                            objrk_lectura.idsuscriptor = vasuscriptorcompleto;
                            objrk_lectura.nombre = vanombre;
                            objrk_lectura.direccion = vadireccion;
                            objrk_lectura.rutalectura = varutalectura;
                            objrk_lectura.idobservacionlectura = vaidobservacionlectura;
                            objrk_lectura.idcausalectura = vaidcausalectura;
                            objrk_lectura.fechatomalectura = dafechatomalectura;
                            objrk_lectura.fechalecturatomada = dafechatomalectura;
                            objrk_lectura.fechamodificacion = dafechatomalectura;
                            objrk_lectura.lecturaanterior = Convert.ToInt32(valecturaanterior);
                            objrk_lectura.consumopromedio = Convert.ToInt32(vaconsumopromedio);
                            objrk_lectura.idusuario = vaidusuario;
                            objrk_lectura.idobservacionlectant = vaidobservacionlectant;
                            objrk_lectura.idvigencia = vaidvigencia;
                            objrk_lectura.idterminalportatil = vaterminalportatil;
                            objrk_lectura.idestadolectura = vaidestadolectura;
                            objrk_lectura.idmedidor = vaidmedidor;
                            objrk_lectura.idtecnico = vaidtecnico;
                            objrk_lectura.observacionfacturada = vaobservacionfacturada;

                            //aqui grabo a la base de datos
                            if (ano == vaano && mes == vames && ciclofacturacion == vaidciclofacturacion)
                            {
                                db.rk_lectura.Add(objrk_lectura);
                                idlectura = idlectura + 1;
                            }
                            else
                            {
                                errorlectura = errorlectura + 1;
                            }
                        }
                        db.SaveChanges();
                        ViewBag.ok = idlectura.ToString();
                        ViewBag.error = errorlectura.ToString();
                    }
                    
                //}
                //catch (Exception e)
                //{
                //    ViewBag.errorArchivo = archivolectura.FileName;
                //    return View();
                //}
            }
            return View();
        }

        // POST: rk_lectura/asignagrupolectura
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult asignagrupolectura(string roland)
        {

            return RedirectToAction("Index");
        }

        // GET: rk_Lectura/Generar Archivo Plano
        public ActionResult generararchivoplano()
        {
            ViewBag.terminalportatil = new SelectList(db.rk_terminalportatil.OrderByDescending(s => s.idterminalportatil), "idterminalportatil", "serie");
            ViewBag.ciclofacturacion = new SelectList(db.rk_ciclofacturacion.OrderByDescending(s => s.idciclofacturacion), "idciclofacturacion", "descripcion");
            return View();
        }

        // POST: rk_lectura/generararchivoplano
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult generararchivoplano(string ciclofacturacion, string ano, string mes, string terminalportatil)
        {
            if (string.IsNullOrEmpty(ano))
            {
                ModelState.AddModelError("ano", "El campo año es obligatorio");
            }
            if (string.IsNullOrEmpty(mes))
            {
                ModelState.AddModelError("mes", "El campo mes es obligatorio");
            }
            if (ModelState.IsValid)
            {
                var archivogenerado = db.rk_lectura.Where(s => s.idestadolectura == "3" && s.idciclofacturacion == ciclofacturacion && s.ano == ano && s.mes == mes && s.idterminalportatil == terminalportatil);
                StringWriter sw = new StringWriter();
                //sw.WriteLine("prueba export csv");
                string nombrearchivo = "LecturasCiclo" + ciclofacturacion + "Ano" + ano + "Mes" + mes + "Terminal" + terminalportatil;
                String prefijo = "5776143";
                int tamanoPrefijo = prefijo.Length;
                Response.ClearContent();
                Response.AddHeader("content-disposition", "attachment;filename=" + nombrearchivo + ".csv");
                Response.ContentType = "text/csv";

                foreach (var line in archivogenerado)
                {
                    int tamanoMatricula = line.idsuscriptor.Length;
                    String matricula = line.idsuscriptor.Substring(tamanoPrefijo, tamanoMatricula - tamanoPrefijo);

                    sw.WriteLine(string.Format("{0};{1};{2};{3};{4}",
                                               matricula,
                                               line.lecturatomada,
                                               line.idobservacionlectura,
                                               line.idservicio,
                                               line.fechalecturatomada));
                }

                Response.Write(sw.ToString());
                Response.End();
                return RedirectToAction("Index");
            }
            return View();
        }

        // GET: rk_Lectura/ActualizarLecturasMasiva
        public ActionResult ActualizarLecturasMasiva()
        {
            ViewBag.ciclofacturacion = new SelectList(db.rk_ciclofacturacion.OrderByDescending(s => s.idciclofacturacion), "idciclofacturacion", "descripcion");
            ViewBag.observaciondelectura = new SelectList(db.rk_observacioneslectura.OrderByDescending(s => s.idobservacionlectura), "idobservacionlectura", "descripcion");
            return View();
        }

        // POST: rk_lectura/ActualizarLecturasMasiva
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ActualizarLecturasMasiva(string ciclofacturacion, string ano, string mes, string rutainicial, string rutafinal)
        {
            if (string.IsNullOrEmpty(ano))
            {
                ModelState.AddModelError("ano", "El campo año es obligatorio");
            }
            if (string.IsNullOrEmpty(mes))
            {
                ModelState.AddModelError("mes", "El campo mes es obligatorio");
            }
            if (string.IsNullOrEmpty(rutainicial))
            {
                ModelState.AddModelError("rutainicial", "El campo ruta inicial es obligatorio");
            }
            if (string.IsNullOrEmpty(rutafinal))
            {
                ModelState.AddModelError("rutafinal", "El campo ruta final es obligatorio");
            }
            /*if (ModelState.IsValid)
            {*/
                ViewBag.ciclofacturacion = new SelectList(db.rk_ciclofacturacion.OrderByDescending(s => s.idciclofacturacion), "idciclofacturacion", "descripcion");
                ViewBag.observaciondelectura = new SelectList(db.rk_observacioneslectura.OrderByDescending(s => s.idobservacionlectura), "idobservacionlectura", "descripcion");

                var rk_lecturaActualizaLectura = db.rk_lectura.Where(s => s.idestadolectura == "2" && s.idciclofacturacion == ciclofacturacion && s.ano == ano && s.mes == mes && s.rutalectura == rutainicial && s.rutalectura == rutafinal);
                return View(rk_lecturaActualizaLectura.ToList());
            //}
            //return View(rk_lecturaActualizaLectura.ToList());
        }

        // GET: rk_Lectura/ConsultaResumenLectura
        public ActionResult ConsultaResumenLectura()
        {
            ViewBag.ciclofacturacion = new SelectList(db.rk_ciclofacturacion.OrderByDescending(s => s.idciclofacturacion), "idciclofacturacion", "descripcion");
            return View();
        }


        // POST: rk_lectura/ConsultaResumenLectura
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ConsultaResumenLectura(string ciclofacturacion, string ano, string mes)
        {
            if (string.IsNullOrEmpty(ano))
            {
                ModelState.AddModelError("ano", "El campo año es obligatorio");
            }
            if (string.IsNullOrEmpty(mes))
            {
                ModelState.AddModelError("mes", "El campo mes es obligatorio");
            }
            ViewBag.ciclofacturacion = new SelectList(db.rk_ciclofacturacion.OrderByDescending(s => s.idciclofacturacion), "idciclofacturacion", "descripcion");
            if (ModelState.IsValid)
            {
                var rk_resumenlectura = from s in db.rk_lectura
                                        where s.idciclofacturacion == ciclofacturacion && s.ano == ano && s.mes == mes
                                        group s by s.idterminalportatil into g
                                        select new LecturaResumen() {
                                            ano = g.FirstOrDefault().ano,
                                            mes = g.FirstOrDefault().mes,
                                            ciclo = g.FirstOrDefault().idciclofacturacion,
                                            terminalportatil = g.FirstOrDefault().idterminalportatil,
                                            asignadas = g.Where(c => c.idestadolectura == "2").Count(),
                                            tomadas  = g.Where(c=> c.idestadolectura=="3").Count(),
                                            faltantes = g.Count() - g.Where(c => c.idestadolectura == "3").Count(),
                                            porcentaje = (g.Where(c => c.idestadolectura == "3").Count() / g.Count())*100
                                        };
                return View(rk_resumenlectura.ToList());
             }
            return View();
        }

        // GET: rk_Lectura/EliminarRegistrosdeLectura
        public ActionResult EliminarRegistrosdeLectura()
        {
            ViewBag.ciclofacturacion = new SelectList(db.rk_ciclofacturacion.OrderByDescending(s => s.idciclofacturacion), "idciclofacturacion", "descripcion");
            return View();
        }


        // POST: rk_lectura/EliminarRegistrosdeLectura
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EliminarRegistrosdeLectura(string ciclofacturacion, string ano, string mes)
        {
            if (string.IsNullOrEmpty(ano))
            {
                ModelState.AddModelError("ano", "El campo año es obligatorio");
            }
            if (string.IsNullOrEmpty(mes))
            {
                ModelState.AddModelError("mes", "El campo mes es obligatorio");
            }
            ViewBag.ciclofacturacion = new SelectList(db.rk_ciclofacturacion.OrderByDescending(s => s.idciclofacturacion), "idciclofacturacion", "descripcion");
            if (ModelState.IsValid)
            {
                ViewBag.vbciclofacturacion = ciclofacturacion;
                ViewBag.vbano = ano;
                ViewBag.vbmes = mes;
                var rk_eliminarLecturas = from s in db.rk_lectura
                                        where s.idestadolectura =="1" && s.idciclofacturacion == ciclofacturacion && s.ano == ano && s.mes == mes
                                        group s by s.idterminalportatil into g
                                        select new LecturaResumen()
                                        {
                                            ano = g.FirstOrDefault().ano,
                                            mes = g.FirstOrDefault().mes,
                                            ciclo = g.FirstOrDefault().idciclofacturacion,
                                            terminalportatil = g.FirstOrDefault().idterminalportatil,
                                            asignadas = g.Count()
                                        };

                return View(rk_eliminarLecturas.ToList());

            }
            return View();
        }

        // GET: rk_Lectura/ConsultaResumenLectura
        public ActionResult EliminarRegistrosdeLecturaConfirma()
        {
            ViewBag.ciclofacturacion = new SelectList(db.rk_ciclofacturacion.OrderByDescending(s => s.idciclofacturacion), "idciclofacturacion", "descripcion");
            return View();
        }

        // POST: rk_lectura/ConsultaResumenLectura
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EliminarRegistrosdeLecturaConfirma(string ciclofacturacion, string ano, string mes, string terminalportatil)
        {
            ViewBag.ciclofacturacion = new SelectList(db.rk_ciclofacturacion.OrderByDescending(s => s.idciclofacturacion), "idciclofacturacion", "descripcion");

            //borrar registros 
            var deleteLecturasPendientes =
            from lectura in db.rk_lectura
            where lectura.idestadolectura == "1"
            && lectura.ano == ano
            && lectura.mes == mes
            && lectura.idciclofacturacion == ciclofacturacion
            && lectura.idterminalportatil == terminalportatil
            select lectura;

            foreach (var lista in deleteLecturasPendientes)
            {
                db.rk_lectura.Remove(lista);
            }

            try
            {
                db.SaveChanges();
                //return View("EliminarRegistrodeLectura");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            //}
            return View("EliminarRegistrosdeLectura");
                         
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
