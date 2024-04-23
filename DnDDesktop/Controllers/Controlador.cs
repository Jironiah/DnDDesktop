using DnDDesktop.Models;
using DnDDesktop.Models.Commons;
using DnDDesktop.Models.Repository;
using DnDDesktop.Views.ViewsPopup;
using System.Xml.Linq;
using System;
using static System.Formats.Asn1.AsnWriter;
using System.Reflection;

namespace DnDDesktop.Controllers
{
    public class Controlador
    {
        Form1 f = new Form1();

        AbilityScoreRepository abilityScoreRepository = new AbilityScoreRepository();
        AlignmentsRepository alignmentsRepository = new AlignmentsRepository();
        WeaponPropertiesRepository weaponPropertiesRepository = new WeaponPropertiesRepository();


        //Listas

        //AbilityScores
        List<From> listaAbilityScoreSkills = new List<From>();
        List<AbilityScore> abilityScores = new List<AbilityScore>();

        //Alignments
        List<Alignment> alignments = new List<Alignment>();

        public Controlador()
        {
            LoadData();
            InitListeners();
            Application.Run(f);
        }

        private void LoadData()
        {
            LoadDataAbilityScore();
            LoadDataAlignments();
        }

        private void LoadDataAbilityScore()
        {
            listaAbilityScoreSkills = abilityScoreRepository.GetAbilityScores().SelectMany(a => a.Skills).ToList();
            f.cbSkillsAbilityScore.DataSource = listaAbilityScoreSkills;
            f.cbSkillsAbilityScore.DisplayMember = "Name";
            abilityScores = abilityScoreRepository.GetAbilityScores();
            f.dgvAbilityScore.DataSource = abilityScores;
        }

        private void LoadDataAlignments()
        {
            alignments = alignmentsRepository.GetAlignments();
            f.dgvAlignments.DataSource = alignments;
        }

        private void InitListeners()
        {
            //AbilityScore
            f.btInsertarAbilityScore.Click += BtInsertarAbilityScore_Click;
            f.cbSkillsAbilityScore.MouseUp += CbSkillsAbilityScore_MouseUp;
            f.btBuscarAbilityScore.Click += BtBuscarAbilityScore_Click;
            f.btEliminarAbilityScore.Click += BtEliminarAbilityScore_Click;
            f.btModificarAbilityScore.Click += BtModificarAbilityScore_Click;
            f.dgvAbilityScore.SelectionChanged += DgvAbilityScore_SelectionChanged;
            //Alignments
            f.btInsertarAlignments.Click += BtInsertarAlignments_Click;
            f.btBuscarAlignments.Click += BtBuscarAlignments_Click;
            f.btEliminarAlignments.Click += BtEliminarAlignments_Click;
            f.btModificarAlignments.Click += BtModificarAlignment_Click;
            f.dgvAlignments.SelectionChanged += DgvAlignments_SelectionChanged;
        }

        //AbilityScore

        private void DgvAbilityScore_SelectionChanged(object? sender, EventArgs e)
        {
            DataGridViewRow row = f.dgvAbilityScore.CurrentRow;
            if (row != null)
            {
                AbilityScore absc = (AbilityScore)row.DataBoundItem;
                f.tbIndexAbilityScore.Text = absc.Index;
                f.tbNameAbilityScore.Text = absc.Name;
                f.tbFullNameAbilityScore.Text = absc.FullName;
                f.rtbDescriptionAbilityScore.Text = absc.Description.FirstOrDefault();
                //f.cbSkillsAbilityScore.DataSource = absc.Skills;
            }
        }

        private void BtInsertarAbilityScore_Click(object? sender, EventArgs e)
        {
            try
            {
                AbilityScore score = new AbilityScore();
                string index = f.tbIndexAbilityScore.Text.ToString();
                string name = f.tbNameAbilityScore.Text.ToString();
                string fullName = f.tbFullNameAbilityScore.Text.ToString();
                string[] description = new string[] { f.rtbDescriptionAbilityScore.Text };

                From selectedSkill = (From)f.cbSkillsAbilityScore.SelectedItem;

                if (!string.IsNullOrEmpty(index) && !string.IsNullOrEmpty(name) && !string.IsNullOrEmpty(fullName))
                {
                    score.Index = index;
                    score.Name = name;
                    score.FullName = fullName;
                    score.Description = description;
                    if (selectedSkill != null)
                    {
                        score.Skills = new From[] { selectedSkill };
                    }
                    abilityScoreRepository.CreateAbilityScore(score);
                    MessageBox.Show("AbilityScore introducido");
                }
                else
                {
                    MessageBox.Show("No puedes dejar espacios vacíos");
                }
                LoadDataAbilityScore();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void CbSkillsAbilityScore_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Middle)
            {
                try
                {
                    string index = f.tbIndexAbilityScore.Text.ToString();
                    string name = f.tbNameAbilityScore.Text.ToString();
                    string fullName = f.tbFullNameAbilityScore.Text.ToString();
                    string[] description = new string[] { f.rtbDescriptionAbilityScore.Text };

                    From emptySkill = new From
                    {
                        Index = string.Empty,
                        Name = string.Empty
                    };

                    if (!string.IsNullOrEmpty(index) && !string.IsNullOrEmpty(name) && !string.IsNullOrEmpty(fullName))
                    {
                        abilityScoreRepository.CreateAbilityScore(new AbilityScore
                        {
                            Index = index,
                            Name = name,
                            FullName = fullName,
                            Description = description,
                            Skills = new From[] { emptySkill }
                        });

                        listaAbilityScoreSkills = abilityScoreRepository.GetAbilityScores().SelectMany(a => a.Skills).ToList();
                        listaAbilityScoreSkills.Insert(0, emptySkill);

                        f.cbSkillsAbilityScore.DataSource = listaAbilityScoreSkills;
                        MessageBox.Show("AbilityScore sin skills introducido");
                    }
                    LoadDataAbilityScore();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }

        private void BtBuscarAbilityScore_Click(object? sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(f.tbFiltrarAbilityScore.Text))
                {
                    string idBuscar = abilityScores.Where(a => a.Index.Equals(f.tbFiltrarAbilityScore.Text.ToString())).Select(a => a.Id.ToLower().ToString()).FirstOrDefault();

                    if (idBuscar != null)
                    {
                        AbilityScore newAbilityScore = abilityScoreRepository.GetAbilityScore(idBuscar.ToString());
                        f.tbIndexAbilityScore.Text = newAbilityScore.Index;
                        f.tbNameAbilityScore.Text = newAbilityScore.Name;
                        f.tbFullNameAbilityScore.Text = newAbilityScore.FullName;
                        f.rtbDescriptionAbilityScore.Text += newAbilityScore.Description.FirstOrDefault();
                        f.cbSkillsAbilityScore.DataSource = newAbilityScore.Skills;
                    }
                    else
                    {
                        MessageBox.Show("No existe una referencia con ese index");
                    }

                }
                else
                {
                    MessageBox.Show("Lo que quieres buscar no puede estar vacío");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void BtEliminarAbilityScore_Click(object? sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(f.tbFiltrarAbilityScore.Text))
                {
                    string idBuscar = abilityScores.Where(a => a.Index.Equals(f.tbFiltrarAbilityScore.Text.ToString())).Select(a => a.Id.ToLower().ToString()).FirstOrDefault();
                    if (idBuscar != null)
                    {
                        abilityScoreRepository.DeleteAbilityScore(idBuscar);
                        MessageBox.Show(f.tbFiltrarAbilityScore.Text.ToString() + " eliminado");
                        LoadDataAbilityScore();
                    }
                    else
                    {
                        MessageBox.Show("No existe una referencia con ese index");
                    }

                }
                else
                {
                    MessageBox.Show("Lo que quieres buscar no puede estar vacío");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void BtModificarAbilityScore_Click(object? sender, EventArgs e)
        {
            try
            {
                string index = f.tbIndexAbilityScore.Text.ToString();
                string name = f.tbNameAbilityScore.Text.ToString();
                string fullName = f.tbFullNameAbilityScore.Text.ToString();
                string[] description = new string[] { f.rtbDescriptionAbilityScore.Text };
                AbilityScore abilityScoreModificar = new AbilityScore();

                if (!string.IsNullOrEmpty(index) && !string.IsNullOrEmpty(name) && !string.IsNullOrEmpty(fullName))
                {
                    From selectedSkill = (From)f.cbSkillsAbilityScore.SelectedItem;
                    string idBuscar = abilityScores.Where(a => a.Index.Equals(f.tbFiltrarAbilityScore.Text.ToString())).Select(a => a.Id.ToLower().ToString()).FirstOrDefault();
                    if (idBuscar != null)
                    {
                        abilityScoreModificar.Id = idBuscar;
                        abilityScoreModificar.Index = index;
                        abilityScoreModificar.Name = name;
                        abilityScoreModificar.FullName = fullName;
                        abilityScoreModificar.Description = description;
                        if (selectedSkill != null)
                        {
                            abilityScoreModificar.Skills = new From[] { selectedSkill };
                        }
                        abilityScoreRepository.UpdateAbilityScore(abilityScoreModificar);
                        MessageBox.Show("Modificado correctamente");
                        LoadDataAbilityScore();
                    }
                    else
                    {
                        MessageBox.Show("No existe una referencia con ese index");
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        //Alignments
        private void BtInsertarAlignments_Click(object? sender, EventArgs e)
        {
            try
            {
                Alignment alignment = new Alignment();
                string index = f.tbIndexAlignments.Text.ToString();
                string name = f.tbNameAlignments.Text.ToString();
                string abbreviation = f.tbAbbreviationAlignments.Text.ToString();
                string description = f.rtbDescriptionAlignments.Text;
                if (!string.IsNullOrEmpty(index) && !string.IsNullOrEmpty(name) && !string.IsNullOrEmpty(abbreviation))
                {
                    alignment.Index = index;
                    alignment.Name = name;
                    alignment.Abbreviation = abbreviation;
                    alignment.Description = description;

                    alignmentsRepository.CreateAlignment(alignment);
                    MessageBox.Show("Alignments introducido");
                    LoadDataAlignments();
                }
                else
                {
                    MessageBox.Show("No puedes dejar espacios vacíos");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }

        }

        private void BtBuscarAlignments_Click(object? sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(f.tbFiltrarAlignments.Text))
                {
                    string idBuscar = alignments.Where(a => a.Index.Equals(f.tbFiltrarAlignments.Text.ToString())).Select(a => a.Id.ToLower().ToString()).FirstOrDefault();

                    //MessageBox.Show(idBuscar);
                    if (idBuscar != null)
                    {
                        Alignment newAlignments = alignmentsRepository.GetAlignment(idBuscar.ToString());
                        f.tbIndexAlignments.Text = newAlignments.Index;
                        f.tbNameAlignments.Text = newAlignments.Name;
                        f.tbAbbreviationAlignments.Text = newAlignments.Abbreviation;
                        f.rtbDescriptionAlignments.Text = newAlignments.Description;
                    }
                    else
                    {
                        MessageBox.Show("No existe una referencia con ese index");
                    }

                }
                else
                {
                    MessageBox.Show("Lo que quieres buscar no puede estar vacío");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void BtEliminarAlignments_Click(object? sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(f.tbFiltrarAlignments.Text))
                {
                    string idBuscar = alignments.Where(a => a.Index.Equals(f.tbFiltrarAlignments.Text.ToString())).Select(a => a.Id.ToLower().ToString()).FirstOrDefault();
                    if (idBuscar != null)
                    {
                        alignmentsRepository.DeleteAlignment(idBuscar);
                        MessageBox.Show(f.tbFiltrarAlignments.Text.ToString() + " eliminado");
                        LoadDataAlignments();
                    }
                    else
                    {
                        MessageBox.Show("Lo que quieres eliminar no puede estar vacío o no existe");
                    }
                }
                else
                {
                    MessageBox.Show("Lo que quieres buscar no puede estar vacío");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }

        }

        private void BtModificarAlignment_Click(object? sender, EventArgs e)
        {
            try
            {
                string index = f.tbIndexAlignments.Text.ToString();
                string name = f.tbNameAlignments.Text.ToString();
                string abbreviation = f.tbAbbreviationAlignments.Text.ToString();
                string description = f.rtbDescriptionAlignments.Text;

                Alignment alignmentModificar = new Alignment();

                if (!string.IsNullOrEmpty(index) && !string.IsNullOrEmpty(name) && !string.IsNullOrEmpty(abbreviation))
                {
                    string idBuscar = alignments.Where(a => a.Index.Equals(f.tbFiltrarAlignments.Text.ToString())).Select(a => a.Id.ToLower().ToString()).FirstOrDefault();
                    if (idBuscar != null)
                    {
                        alignmentModificar.Id = idBuscar;
                        alignmentModificar.Index = index;
                        alignmentModificar.Name = name;
                        alignmentModificar.Abbreviation = abbreviation;
                        alignmentModificar.Description = description;

                        alignmentsRepository.UpdateAlignment(alignmentModificar);
                        MessageBox.Show("Modificado correctamente");
                        LoadDataAlignments();
                    }
                    else
                    {
                        MessageBox.Show("Lo que quieres modificar no puede estar vacío");
                    }
                }
                else
                {
                    MessageBox.Show("No puedes dejar espacíos vacíos");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void DgvAlignments_SelectionChanged(object? sender, EventArgs e)
        {
            DataGridViewRow row = f.dgvAlignments.CurrentRow;
            if (row != null)
            {
                Alignment alig = (Alignment)row.DataBoundItem;
                f.tbIndexAlignments.Text = alig.Index;
                f.tbAbbreviationAlignments.Text = alig.Abbreviation;
                f.tbNameAlignments.Text = alig.Name;
                f.rtbDescriptionAlignments.Text = alig.Description;
            }
        }
    }
}
