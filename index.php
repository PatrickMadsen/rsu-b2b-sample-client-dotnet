<?php

    /* $Angivelsesafgifter = array(
        "MomAngivelseAfgiftTilsvarBeloeb" => "100",
        "MomsAngivelseCO2AfgiftBeloeb" => "0",
        "MomsAngivelseEUKoebBeloeb" => "0",
        "MomsAngivelseEUSalgBeloebVarerBeloeb" => "0",
        "MomsAngivelseIkkeEUSalgBeloebVarerBeloeb" => "0",
        "MomsAngivelseElAfgiftBeloeb" => "0",
        "MomsAngivelseEksportOmsaetningBeloeb" => "0",
        "MomsAngivelseGasAfgiftBeloeb" => "0",
        "MomsAngivelseKoebsMomsBeloeb" => "0",
        "MomsAngivelseKulAfgiftBeloeb" => "0",
        "MomsAngivelseMomsEUKoebBeloeb" => "0",
        "MomsAngivelseMomsEUYdelserBeloeb" => "0",
        "MomsAngivelseOlieAfgiftBeloeb" => "0",
        "MomsAngivelseSalgsMomsBeloeb" => "0",
        "MomsAngivelseVandAfgiftBeloeb" => "0",
        "MomsAngivelseEUKoebYdelseBeloeb" => "0",
        "MomsAngivelseEUSalgYdelseBeloeb" => "0"
    ); */
    $data = [
        "command" => "ModtagMomsangivelseForeloebig",
        "dateFrom" => "2024-03-01",
        "dateTo" => "2024-06-03",
        "cvr" => 41250313,
        "MomsAngivelseAfgiftTilsvarBeloeb" => "100",
        "MomsAngivelseCO2AfgiftBeloeb" => "0",
        "MomsAngivelseEUKoebBeloeb" => "0",
        "MomsAngivelseEUSalgBeloebVarerBeloeb" => "0",
        "MomsAngivelseIkkeEUSalgBeloebVarerBeloeb" => "0",
        "MomsAngivelseElAfgiftBeloeb" => "0",
        "MomsAngivelseEksportOmsaetningBeloeb" => "0",
        "MomsAngivelseGasAfgiftBeloeb" => "0",
        "MomsAngivelseKoebsMomsBeloeb" => "0",
        "MomsAngivelseKulAfgiftBeloeb" => "0",
        "MomsAngivelseMomsEUKoebBeloeb" => "0",
        "MomsAngivelseMomsEUYdelserBeloeb" => "0",
        "MomsAngivelseOlieAfgiftBeloeb" => "0",
        "MomsAngivelseSalgsMomsBeloeb" => "0",
        "MomsAngivelseVandAfgiftBeloeb" => "0",
        "MomsAngivelseEUKoebYdelseBeloeb" => "0",
        "MomsAngivelseEUSalgYdelseBeloeb" => "0"
    ];

/*     $data = [
        "command" => "VirksomhedKalenderHent",
        "dateFrom" => "2024-01-01",
        "dateTo" => "2024-12-31",
        "cvr" => 41250313,
    ]; */
    $data = json_encode($data);
    $data = str_replace('"', '\\"', $data); // Escape inner double quotes
    $command = 'dotnet run "' . $data . '" 2>&1';
    echo $command;
/*     $output = shell_exec($command);
    var_dump($output); */

?>