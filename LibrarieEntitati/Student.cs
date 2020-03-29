namespace LibrarieEntitati
{
    public class Student
    {
        // date membre private
        string nume, prenume;
        int[,] note;
        int id;

        // contructor implicit
        public Student()
        {
            note = new int[3, 14];
        }

        // constructor cu parametri
        public Student(string _nume, string _prenume)
        {
            nume = _nume;
            prenume = _prenume;
        }

        public Student(string date_fisier)
        {
            string[] date;
            date = date_fisier.Split(',');
            id = System.Convert.ToInt32(date[0]);
            prenume = date[1];
            nume = date[2];
            SetNote(date[3]);
        }

        public void SetNote(string sirNote)
        {
            note = new int[4, 15];
            string[] sir_note_an = sirNote.Split(',');
            string[] sir_note_obiecte;
            for(int i=0; i < sir_note_an.Length; i++)
            {
                sir_note_obiecte = sir_note_an[i].Split(' ');
                for(int j=0; j< sir_note_obiecte.Length; j++)
                {
                    int nota_int;
                    bool Rez = System.Int32.TryParse(sir_note_obiecte[j], out nota_int);
                    if (Rez == true)
                    { 
                        if (nota_int > 0 && nota_int <= 10)
                        {
                            note[i,j] = nota_int;
                        }
                    }
                }
                
            }
        }

        public void SetNote(int an, int[] _note)
        {
            for(int i=0;  i< _note.Length; i++)
            {
                note[an-1,i] = _note[i];
            }
        }
        public string ConversieLaSir()
        {
            string sNote = "Nu exista (Nu ati apelat metoda **setNote**)";
            string nume_complet = nume;
            if (note != null)
            {
                for(int i=0; i<4;i++)
                {
                    sNote += string.Format("\nAnul {0}: \n", i);
                    for(int j=0;j<15;j++)
                        sNote += note[i,j] + " ";

                }
            }
            if (string.IsNullOrEmpty(prenume) == false)
                nume_complet += " " + prenume;
            string s = string.Format("Studentul {0} are notele:.... {1}", nume_complet, sNote);

            return s;
        }

        public void NumarareNote(int an, out int valSub5,out int valPeste5)
        {
            valSub5 = valPeste5 = 0;
            for(int i=0; i<15; i++)
            {
                if (note[an, i] < 5)
                    valSub5++;
                else
                    valPeste5++;
            }
        }
    }
}
