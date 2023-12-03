[HttpPost]
public IActionResult Create(Customer c)
{
    // Vérifier la validité du modèle
    if (!ModelState.IsValid)
    {
        // En cas d'erreurs de validation, récupérer à nouveau la liste des types d'adhésion
        var members = _db.membershiptypes.ToList();

        // Recréer la liste déroulante dans ViewBag
        ViewBag.member = members.Select(members => new SelectListItem()
        {
            Text = members.Name,
            Value = members.Id.ToString()
        });

        // Retourner la vue avec les erreurs de validation affichées
        return View();
    }

    // Si le modèle est valide, ajouter le client à la base de données
    c.CustomerId = new Guid();
    _db.customers.Add(c);
    _db.SaveChanges();

    // Rediriger vers l'action Index après la création réussie
    return RedirectToAction(nameof(Index));
}


