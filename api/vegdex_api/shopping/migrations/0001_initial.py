# Generated by Django 4.1.7 on 2023-03-20 01:02

from django.db import migrations, models
import django.db.models.deletion


class Migration(migrations.Migration):

    initial = True

    dependencies = [
        ('common', '0001_initial'),
    ]

    operations = [
        migrations.CreateModel(
            name='VeganCompany',
            fields=[
                ('id', models.BigAutoField(auto_created=True, primary_key=True, serialize=False, verbose_name='ID')),
                ('name', models.CharField(max_length=200)),
                ('slug', models.SlugField(editable=False, unique=True)),
                ('website', models.CharField(blank=True, max_length=2000)),
                ('description', models.TextField(blank=True)),
            ],
            options={
                'verbose_name_plural': 'vegan companies',
            },
        ),
        migrations.CreateModel(
            name='FarmersMarket',
            fields=[
                ('id', models.BigAutoField(auto_created=True, primary_key=True, serialize=False, verbose_name='ID')),
                ('hours', models.TextField(blank=True)),
                ('name', models.CharField(max_length=200)),
                ('slug', models.SlugField(editable=False, max_length=200, unique=True)),
                ('phone', models.CharField(blank=True, max_length=20)),
                ('website', models.CharField(blank=True, max_length=2000)),
                ('address', models.ForeignKey(on_delete=django.db.models.deletion.CASCADE, to='common.address')),
            ],
            options={
                'abstract': False,
            },
        ),
    ]
