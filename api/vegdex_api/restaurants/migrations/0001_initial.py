# Generated by Django 4.1.7 on 2023-03-19 22:26

from django.db import migrations, models
import django.db.models.deletion


class Migration(migrations.Migration):

    initial = True

    dependencies = [
        ('generic', '__first__'),
    ]

    operations = [
        migrations.CreateModel(
            name='Restaurant',
            fields=[
                ('id', models.BigAutoField(auto_created=True, primary_key=True, serialize=False, verbose_name='ID')),
                ('name', models.CharField(max_length=200)),
                ('date_created', models.DateTimeField(auto_now_add=True, verbose_name='date_published')),
                ('date_updated', models.DateTimeField(auto_now=True)),
                ('slug', models.SlugField(editable=False, max_length=200, unique=True)),
                ('website', models.CharField(blank=True, max_length=2000)),
                ('description', models.TextField(blank=True)),
                ('all_vegan', models.BooleanField(default=False)),
                ('location', models.ForeignKey(on_delete=django.db.models.deletion.CASCADE, to='generic.city')),
            ],
            options={
                'abstract': False,
            },
        ),
    ]