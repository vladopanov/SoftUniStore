namespace SoftUniStore.ViewModels
{
    public class AdminGamesViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public double Size { get; set; }

        public decimal Price { get; set; }

        public override string ToString()
        {
            string tableRow = $@"<tr>
                        <td>{this.Name}</td>
                        <td>{this.Size} GB</td>
                        <td>{this.Price} &euro;</td>
                        <td>
                            <a href=""/admin/edit?id={this.Id}"" class=""btn btn-warning btn-sm"">Edit</a>
                            <a href=""/admin/delete?id={this.Id}"" class=""btn btn-danger btn-sm"">Delete</a>
                        </td>
                    </tr>";

            return tableRow;
        }
    }
}
