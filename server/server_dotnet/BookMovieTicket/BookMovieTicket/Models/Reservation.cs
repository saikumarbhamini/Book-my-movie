using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;

namespace BookMovieTicket.Models;

public class Reservation
{
    public int Id { get; set; }
    public UserData? User { get; set; }
    public Show? SelectedShow { get; set; }
    [MaxLength(225)]
    public string? ReservationCode { get; set; }
    public ICollection<Seat> Seats { get; set; } = null!;
}