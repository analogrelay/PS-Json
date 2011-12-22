$acc = [Type]::GetType("System.Management.Automation.TypeAccelerators, System.Management.Automation");
if($acc::Add) {
	$acc::Add("json", [PsJson.JsonObject]);
} elseif($acc::AddReplace) {
	# Added in PowerShell 3.0
	$acc::AddReplace("json", [PsJson.JsonObject]);
}