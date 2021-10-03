<?php

require_once "config/config.php";

abstract class AbstractTable
{
    private static $connexion;

    protected function __construct()
    {
    }

    protected function getConnexion(): PDO
    {
        try {
            // You'll understand that I don't provide the config file with the database password...
            if (AbstractTable::$connexion == null) {
                AbstractTable::$connexion = new PDO("mysql:host=" . DB_HOST . ";port=" . DB_PORT . ";dbname=" . DB_NAME . ";charset=utf8", DB_USER, DB_PASS);
                AbstractTable::$connexion->setAttribute(PDO::ATTR_ERRMODE, PDO::ERRMODE_EXCEPTION);
            }
            return AbstractTable::$connexion;
        } catch (Exception $e) {
            die($e->getMessage());
        }
    }


}
