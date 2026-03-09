using System.Collections.Generic;

namespace WpfApp1
{
    public class Cadastro<T>
    {
        private Dictionary<int, T> dados = new Dictionary<int, T>();

        public void Adicionar(int id, T item)
        {
            dados[id] = item;
        }

        public Dictionary<int, T> Listar()
        {
            return dados;
        }

        public T Buscar(int id)
        {
            if (dados.ContainsKey(id))
                return dados[id];

            return default(T);
        }

        public bool Remover(int id)
        {
            return dados.Remove(id);
        }
    }
}